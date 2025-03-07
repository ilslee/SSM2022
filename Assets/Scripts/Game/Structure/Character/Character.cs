using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using ssm.data.item;
using System.Linq;
using System;
using ssm.game.structure.token;
using ssm.data.token;
using Unity.VisualScripting;
namespace ssm.game.structure{    
    public class Character
    {
        public int index;
        // public ModifierList stat; // 현재스탯, 최대 스탯을 한번에 모아둠
        
        public bool isBPCharacter;
        public BPManager bpManager;
        
        // public GameTokenList token;                
        public TokenList staticTokens;                
        public List<PlayData> playData;
        
        public TokenList temporaryTokens; // expectation 임시 보관용
        
        public Character(PlayableCharacter data, int index){
            Debug.Log("Character : Initiate character as index = " + index);
            this.index = index;
            

            staticTokens = new TokenList(index);
            //동작 처리하는 GameToken 추가
            staticTokens.Combine(new AttackAction());
            staticTokens.Combine(new StrikeAction());
            staticTokens.Combine(new DefenceAction());
            staticTokens.Combine(new ChargeAction());
            staticTokens.Combine(new RestAction());
            staticTokens.Combine(new AvoidAction());
            
            temporaryTokens = new TokenList();
            AddPlayData();//턴 수와 data수를 맞추기 위해 & 0항목에는 시작 데이터가 들어감
            
            

            if(data is BPCharacter){
                isBPCharacter = true;
                bpManager = new BPManager();
                foreach (BPData item in (data as BPCharacter).bp)
                {
                    bpManager.Add(new BehaviourPattern(index, item));
                }
                // Debug.Log("Character " + index + " is a BP Character with " + (data as BPCharacter).bp.Count + " BPs.");
            }else{
                isBPCharacter = false;
            }
            
            

                       
        }

        public void InitializeTokens(PlayableCharacter data){
            // AddSetItems(); // 기존 아이템을 보고 어떤 세트를 추가할 지 결정'
            TokenList tempStaticToken = new TokenList(index);
            TokenList tempPlayData = new TokenList(index);
            //Core의 스탯을 분배
            ConvertAndDistributeToken(data.core);
            foreach(ItemData i in data.item){
                //itemData의 TokenData를 GameToken으로 변환하여 재분배
                ConvertAndDistributeToken(i.tokens);
            }
            
            void ConvertAndDistributeToken(List<Token> tokenList){
                foreach(ssm.data.token.Token t in tokenList){
                    GameToken gameToken = GameTokenConverter.Convert(t);
                    if(gameToken.occasion == GameTerms.TokenOccasion.Dynamic) tempPlayData.Add(gameToken);
                    else tempStaticToken.Add(gameToken);
                }
            }
            
            staticTokens.Combine(tempStaticToken);
            // Debug.Log(staticTokens.ToString());
            GetLastPlayData().Combine(tempPlayData);
            // Debug.Log(GetLastPlayData().ToString());
            void AddSetItems(){
                List<ItemData> setItems = new List<ItemData>();
                int familyCount = System.Enum.GetValues(typeof(ItemData.Family)).Length;
                for (int i = 0; i < familyCount; i++)
                {
                    ItemData.Family f = (ItemData.Family)i;
                    if(f == ItemData.Family.None || f == ItemData.Family.Basic){
                        
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
            
            playData.Add(new PlayData(index));            
            //지난 Stat 이관
            if(playData.Count > 1){
                GetLastPlayData().Inherit(GetLastPlayData(1));                
            }
            temporaryTokens.Clear();
            // Debug.Log("Character.AddPlayData() : " + GetLastPlayData().token.ToString());
        }

        public PlayData GetLastPlayData(int count = 0){
            int index = GetLastPlayDataIndex(count);
            if(count != 0){
                Debug.Log("Character.GetLastPlayData() - not the last number is called. Converted ID : " +index );
            }
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
        
        //Static, Temp, LastPlayData에서 지정 타입의 토큰을 찾는다
        public GameToken SearchToken(GameTerms.TokenType t, GameTerms.TokenOccasion o = GameTerms.TokenOccasion.None){
            GameToken resultValue =  new GameToken(t, o);
            resultValue.characterIndex = index;
            resultValue.Combine(staticTokens.Find(t, o));
            resultValue.Combine(temporaryTokens.Find(t, o));
            resultValue.Combine(GameBoard.Instance().FindCharacter(index).GetLastPlayData().Find(t, o));
            return resultValue;
        }
        //Static, Temp, LastPlayData에서 지정 상황의 토큰 리스트를 찾는다
        private TokenList SearchTokenList(GameTerms.TokenOccasion o){
            TokenList resultValue =  new TokenList();
            resultValue.characterIndex = this.index;
            foreach(GameToken t in staticTokens.FindAll(o)){
                resultValue.Combine(t);
            }
            foreach(GameToken t in temporaryTokens.FindAll(o)){
                resultValue.Combine(t);
            }
            foreach(GameToken t in GameBoard.Instance().FindCharacter(index).GetLastPlayData().FindAll(o)){
                resultValue.Combine(t);
            }
            return resultValue;
        }
       
        //------------------------------[TurnStart] : 
        public void ApplyTurnStart(){
            foreach(GameToken t in SearchTokenList(GameTerms.TokenOccasion.TurnStart)){
                t.Yeild();
            }
        }
        //------------------------------[Expectation]
        public void ExpectPower(){
            staticTokens.Find(GameTerms.TokenType.AttackAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.StrikeAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.DefenceAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.ChargeAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.RestAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.AvoidAction).Yeild();
            // Debug.Log("[After Expectation]------------");
            // Debug.Log(temporaryTokens.ToString());
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
            switch(GetLastPlayData().motion){
                case GameTerms.Motion.None:
                break;
                case GameTerms.Motion.Attack:
                staticTokens.Find(GameTerms.TokenType.AttackAction).Yeild();
                break;
                case GameTerms.Motion.Strike:
                staticTokens.Find(GameTerms.TokenType.StrikeAction).Yeild();
                break;
                case GameTerms.Motion.Defence:
                staticTokens.Find(GameTerms.TokenType.DefenceAction).Yeild();
                break;
                case GameTerms.Motion.Charge:
                staticTokens.Find(GameTerms.TokenType.ChargeAction).Yeild();
                break;
                case GameTerms.Motion.Rest:
                staticTokens.Find(GameTerms.TokenType.RestAction).Yeild();
                break;
                case GameTerms.Motion.Avoid:
                staticTokens.Find(GameTerms.TokenType.AvoidAction).Yeild();
                break;
            }
            // Debug.Log("[After FinalizePower]------------");
            // Debug.Log(GetLastPlayData().ToString());
        }
        
        public void ComparePower(){
            TotalPower tp = GetLastPlayData().Find(GameTerms.TokenType.TotalPower) as TotalPower;
            tp.Yeild(); // >> Damage
            
            // Debug.Log("[After ComparePower]------------");
            // Debug.Log(GetLastPlayData().ToString());
        }

        public void ApplyConsumption(){
            if( GetLastPlayData().Has(GameTerms.TokenType.EnergyPower) == true){
                EnergyPower ep = GetLastPlayData().Find(GameTerms.TokenType.EnergyPower) as EnergyPower;
                ep.Yeild(); // >> Consumtion of EPCurrent
            }
            TokenList consumptions = SearchTokenList(GameTerms.TokenOccasion.Consumption);
            foreach(GameToken t in consumptions){
                t.Yeild(); 
            }
            // Debug.Log("[After ApplyConsumption]------------");
            // Debug.Log(GetLastPlayData().ToString());
        }

        public void ApplyDamage(){
            if(GetLastPlayData().Has(GameTerms.TokenType.Damage) == false)return;
            Damage dm = GetLastPlayData().Find(GameTerms.TokenType.Damage) as Damage;
            dm.Yeild(); // >> Damaeg of HPCurrent
            TokenList damages = SearchTokenList(GameTerms.TokenOccasion.Damage);
            foreach(GameToken t in damages){
                t.Yeild(); 
            }
            // Debug.Log("[After ApplyDamage]------------");
            // Debug.Log(GetLastPlayData().ToString());
        }
        
        public void Feedback(){
            

            foreach(GameToken t in SearchTokenList(GameTerms.TokenOccasion.Feedback)){
                t.Yeild();
            }
            // Debug.Log("[After Feedback]------------");
            // Debug.Log(GetLastPlayData().ToString());
        }
        
    }


}