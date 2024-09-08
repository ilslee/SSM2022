using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using System.Linq;
using System;
using ssm.data.token;
namespace ssm.game.structure{    
    public class Character
    {
        public int index;
        // public ModifierList stat; // 현재스탯, 최대 스탯을 한번에 모아둠
        
        public bool isBPCharacter;
        public BPManager behaviourPattern;
        
        // public GameTokenList token;                
        public TokenList staticTokens;                
        public List<PlayData> playData;
        
        public TokenList temporaryTokens;
        
        public Character(PlayableCharacter data, int index){
            this.index = index;
            AddSetItems(); // 기존 아이템을 보고 어떤 세트를 추가할 지 결정'

            AddPlayData();//턴 수와 data수를 맞추기 위해 & 0항목에는 시작 데이터가 들어감
            staticTokens = new TokenList();

            TokenList tempStaticToken = new TokenList();
            TokenList tempPlayData = new TokenList();
            foreach(ItemData i in data.item){
                foreach(Token t in i.tokens){
                    t.characterIndex = this.index;
                    if(t.occasion == GameTerms.TokenOccasion.Dynamic)tempPlayData.Add(t);
                    else tempStaticToken.Add(t);
                }
            }
            tempStaticToken.Combine(tempStaticToken);
            GetLastPlayData().Combine(tempPlayData);
            
            
            if(data is BPCharacter){
                isBPCharacter = true;
                behaviourPattern = new BPManager();
                foreach (var item in (data as BPCharacter).bp)
                {
                    behaviourPattern.Add(new BehaviourPattern(item));
                }
                // Debug.Log("Character " + index + " is a BP Character with " + (data as BPCharacter).bp.Count + " BPs.");
            }else{
                isBPCharacter = false;
            }
            
            

            void AddSetItems(){
                List<ItemData> setItems = new List<ItemData>();
                int familyCount = System.Enum.GetValues(typeof(ItemData.Family)).Length;
                for (int i = 0; i < familyCount; i++)
                {
                    ItemData.Family f = (ItemData.Family)i;
                    if(f == ItemData.Family.None || f == ItemData.Family.Default){
                        
                    }else{
                        if(data.item.Count(t => t.family == f && t.grade >= 2) >= 6){
                            Debug.Log("Add Set Item of " + f.ToString() + " with grade 2");
                            // setItems.Add(itemContainer.ConvertItem(new ItemIndexer(f, GameTerms.ItemPart.Set, 2)));
                        }else if(data.item.Count(t => t.family == f && t.grade >= 1) >= 4){
                            Debug.Log("Add Set Item of " + f.ToString() + " with grade 1");
                            // setItems.Add(itemContainer.ConvertItem(new ItemIndexer(f, GameTerms.ItemPart.Set, 1)));                            
                        }else if(data.item.Count(t => t.family == f && t.grade >= 0) >= 2){
                            Debug.Log("Add Set Item of " + f.ToString() + " with grade 0");
                            // setItems.Add(itemContainer.ConvertItem(new ItemIndexer(f, GameTerms.ItemPart.Set, 0)));
                        }                       
                    }
                }
                
                // item.AddRange(setItems);
            }            
        }

        

        public void AddPlayData(){
            if(playData == null) playData = new List<PlayData>();
            
            playData.Add(new PlayData());            
            //지난 Stat 이관
            if(playData.Count > 1){
                GetLastPlayData().Inherit(GetLastPlayData(1));                
            }
            temporaryTokens.Clear();
            // Debug.Log("Character.AddPlayData() : " + GetLastPlayData().token.ToString());
        }

        public PlayData GetLastPlayData(int count = 0){
            int index = GetLastPlayDataIndex(count);
            if(index >= 0) return playData[index];
            else {
                GetLastPlayDataError();
                return null;
            }
            
            void GetLastPlayDataError(){
                Debug.LogError("GameBoard.GetLastPlayDataViaIndex - There is no game Data at : " + count);            
            }
        }
        
        private int GetLastPlayDataIndex(int count = 0){
            int index = playData.Count -1 -count;
            if(index >= 0) return index;
            else return -1;
        }
        
        //Static과 Temp에서 지정 타입의 토큰을 찾는다
        public Token SearchToken(GameTerms.TokenType t){
            Token resultValue =  new Token(index, t, GameTerms.TokenOccasion.None);
            resultValue.Combine(staticTokens.Find(t));
            resultValue.Combine(temporaryTokens.Find(t));
            return resultValue;
        }
        //Static과 Temp에서 지정 상황의 토큰 리스트를 찾는다
        private TokenList SearchTokenList(GameTerms.TokenOccasion o){
            TokenList resultValue =  new TokenList();
            foreach(Token t in staticTokens.FindAll(o)){
                resultValue.Combine(t);
            }
            foreach(Token t in temporaryTokens.FindAll(o)){
                resultValue.Combine(t);
            }
            return resultValue;
        }
        //------------------------------[Recovery]
        public void CalculateRecoveries(){
            foreach(Token t in SearchTokenList(GameTerms.TokenOccasion.Recover)){
                t.Yeild();
            }
        }
        //------------------------------[Expectation]
        public void ExpectPower(){
            TokenList tempTL = new TokenList();
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Attack));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Strike));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Defence));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Charge));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Rest));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Avoid));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Sword));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Shield));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Move));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Offensive));
            tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Defensive));
            foreach(Token t in tempTL){
                temporaryTokens.Combine(t.Yeild());
            }
        }
       
        public void CalcuateCollision(){
            GameTerms.Motion myMotion = GetLastPlayData().motion;
            GameTerms.Motion otherMotion = GameBoard.Instance().FindOpponent(index).GetLastPlayData().motion;
            bool isCollide = false;
            switch(myMotion){
                case GameTerms.Motion.None:
                    switch(otherMotion){
                        // case GameTerms.Motion.None:
                        // case GameTerms.Motion.Defence:
                        // case GameTerms.Motion.Rest:
                        // case GameTerms.Motion.Avoid:
                        // break;
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Attack:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Defence:
                        case GameTerms.Motion.Charge:
                        case GameTerms.Motion.Rest:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Strike:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Defence:
                        case GameTerms.Motion.Charge:
                        case GameTerms.Motion.Rest:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Defence:
                    switch(otherMotion){
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Charge:
                    switch(otherMotion){
                        case GameTerms.Motion.None:
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Defence:
                        case GameTerms.Motion.Charge:
                        case GameTerms.Motion.Rest:                            
                        case GameTerms.Motion.Avoid:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Rest:
                    switch(otherMotion){
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                    }
                break;
                case GameTerms.Motion.Avoid:
                    switch(otherMotion){
                        case GameTerms.Motion.Charge:
                        isCollide = true;
                        break;
                    }
                break;
            }
            GetLastPlayData().collision = isCollide;
        }
        
        //------------------------------[Consequences] 
        public void FinalizePower(){
            TokenList tempTL = new TokenList();
            switch(GetLastPlayData().motion){
                case GameTerms.Motion.None:
                break;
                case GameTerms.Motion.Attack:
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Attack));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Sword));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Offensive));
                break;
                case GameTerms.Motion.Strike:
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Strike));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Sword));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Offensive));
                break;
                case GameTerms.Motion.Defence:
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Defence));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Shield));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Defensive));
                break;
                case GameTerms.Motion.Charge:
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Charge));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Shield));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Offensive));
                break;
                case GameTerms.Motion.Rest:
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Rest));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Move));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Defensive));
                break;
                case GameTerms.Motion.Avoid:
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Avoid));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Move));
                tempTL.AddRange(SearchTokenList(GameTerms.TokenOccasion.Defensive));
                break;
            }
            foreach(Token t in tempTL){
                GetLastPlayData().Combine(t.Yeild()); // Convey Powers 
            }
        }

        public void CalculateDamage(){
            Power myPower = GetLastPlayData().Find(GameTerms.TokenType.TotalPower) as Power;
            GetLastPlayData().Combine(myPower.Yeild()); // Convey Damage
        }
        public void ModifyStats(){
            Power myPower = GetLastPlayData().Find(GameTerms.TokenType.TotalPower) as Power;
            GetLastPlayData().Combine(myPower.Yeild()); // Consume & Modification
        }
        public void CalculateFeedback(){
            foreach(Token t in SearchTokenList(GameTerms.TokenOccasion.Feedback)){
                t.Yeild();
            }
        }
        
    }


}