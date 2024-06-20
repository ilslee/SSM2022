using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ssm.data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System;
namespace ssm.game.structure{    
    public class Character
    {
        public int index;
        // public ModifierList stat; // 현재스탯, 최대 스탯을 한번에 모아둠
        
        public bool isBPCharacter;
        public BPManager behaviourPattern;
        
        public GameTokenList token;                
        public List<PlayData> playData;
        
        public Expectation expectation;
        
        public Character(PlayableCharacter data, int index){
            this.index = index;
            AddPlayData();//턴 수와 data수를 맞추기 위해 & 0항목에는 시작 데이터가 들어감

            // item = data.item as ItemSet;
            //모든 데이터를 token에 병합
            token = new GameTokenList();
            foreach(ItemData i in data.item){
                foreach(TokenGrade t in i.tokens){
                    float value = t.value0[i.grade];                    
                    switch(t.type){
                        // character.token에 넣을 것(static)
                        case GameTerms.TokenType.MaxHealth:
                        this.token.Combine(new MaxHealth(value));
                        break;
                        // playdata.token에 넣을 것 (active)
                        case GameTerms.TokenType.Health:
                        GetLastPlayData(0).token.Combine(new Health(value));
                        break;
                    }                    
                }
            }
            // Debug.Log(token.ToString()); // Working Good.            
            AddSetItems(); // 기존 아이템을 보고 어떤 세트를 추가할 지 결정
            
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
                GetLastPlayData().InheritGameToken(GetLastPlayData(1).token);                
            }
            expectation.Clear();
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
                Debug.LogError("Gameboard.GetLastPlayDataViaIndex - There is no game Data at : " + count);            
            }
        }
        
        private int GetLastPlayDataIndex(int count = 0){
            int index = playData.Count -1 -count;
            if(index >= 0) return index;
            else return -1;
        }
        
        /*
        public TokenList GetTokenListViaMotion(GameTerms.Motion m){
            switch(m){
                case GameTerms.Motion.None:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionNone) as TokenList;
                case GameTerms.Motion.Attack:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionAttack) as TokenList;
                case GameTerms.Motion.Strike:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionStrike) as TokenList;
                case GameTerms.Motion.Defence:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionDefence) as TokenList;
                case GameTerms.Motion.Charge:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionCharge) as TokenList;
                case GameTerms.Motion.Avoid:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionAvoid) as TokenList;
                case GameTerms.Motion.Taunt:
                return token.FindAll(x => x.occasion == Token.Occasion.OnMotionTaunt) as TokenList;
            }
            return new TokenList();
        }
        */
    }


}