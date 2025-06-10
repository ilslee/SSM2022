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
        
        public TokenList temporaryTokens; // expectation 임시 보관용 : 각종 Power, Consumption (MultiTypeToken)보관
        
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
            //Parts의 데이터를 토큰으로 변환
            foreach(ItemData i in data.part) ConvertAndDistributeToken(i.tokens);            
            //Set의 데이터를 토큰으로 변환
            foreach(ItemData s in data.set) ConvertAndDistributeToken(s.tokens);            
            //Accessories의 데이터를 토큰으로 변환
            foreach(ItemData a in data.accessory) ConvertAndDistributeToken(a.tokens);            
                
            void ConvertAndDistributeToken(List<Token> tokenList){
                
                foreach(ssm.data.token.Token t in tokenList){
                    GameToken gameToken = GameTokenConverter.Convert(t);
                    gameToken.characterIndex = index;
                    
                    //설정에 따라 static과 playData에 나누어 배치
                    if (gameToken.occasion == GameTerms.TokenOccasion.Static) staticTokens.Combine(gameToken);
                    else if (gameToken is PowerInfoGenerator) staticTokens.Combine(gameToken);
                    else GetLastPlayData().Combine(gameToken);                    
                    // if (gameToken.isDynamic == false)
                    
                }
            }
            // Debug.Log(staticTokens.ToString());
            // Debug.Log(GetLastPlayData().ToString());
            //토큰 후처리가 필요한 것들이 있음
            //Vigor : 비율로 표시된 point를 값으로 변환 - HP Max의 등록이 완료된 후 처리되어야 함 -> 자체 처리로 변경 250607
            // GameToken vig = SearchToken(GameTerms.TokenType.Vigor);
            // if(vig is Vigor) (vig as Vigor).SetVigorPoint();
            //recovery : Regenration 제거
            Recovery rec = SearchToken(GameTerms.TokenType.Recovery) as Recovery;
            if(rec is Recovery) (rec as Recovery).RemoveRegeneration();

            string reslt = "[Character " + index + "'s Token List]";
            reslt += "\n ----------<Static>----------";
            foreach(GameToken s in staticTokens) reslt += "\n" + s.ToString() + " / disp : " + s.isDisplayed.ToString();
            reslt += "\n ----------<PlayData>----------";
            foreach(GameToken p in GetLastPlayData()) reslt += "\n" + p.ToString() + " / disp : " + p.isDisplayed.ToString();
            Debug.Log(reslt);

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

        //Static, LastPlayData, Temp에서 순서대로 지정 타입의 토큰을 찾는다. 
        //MultiTypeToken를 찾을때는 이 메소드를 이용하지 않는다
        public GameToken SearchToken(GameTerms.TokenType t, GameTerms.TokenOccasion o = GameTerms.TokenOccasion.None)
        {
            GameToken s = staticTokens.Find(t, o);
            if (s.type != GameTerms.TokenType.None) return s;
            GameToken p = GameBoard.Instance().FindCharacter(index).GetLastPlayData().Find(t, o);
            if (p.type != GameTerms.TokenType.None) return p;
            GameToken e = temporaryTokens.Find(t, o);
            if (e.type != GameTerms.TokenType.None) return e;
            return new GameToken();
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
        //------------------------------[Expectation] Rest 계산 때문에 1,2로 구문
        //1에서는 rest 제외한 나머지 계산, 2에서는 rest 계산
        public void ExpectPower1()
        {
            staticTokens.Find(GameTerms.TokenType.AttackAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.StrikeAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.DefenceAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.ChargeAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.RestAction).Yeild();
            staticTokens.Find(GameTerms.TokenType.AvoidAction).Yeild();
            // Debug.Log("[After Expectation]------------");
            // Debug.Log(temporaryTokens.ToString());

            //1. static과 playData에서 PowerInfoGenerator를 찾음
            //2. 결과에 따라 파싱하여 expectation에 넣는다
            //3. 추가 계산 Energy Power & Consumption 진행
            foreach (GameToken st in staticTokens)
            {
                if (st is PowerInfoGenerator)
                {
                    MultiTypeToken? att = (st as PowerInfoGenerator).YieldMTT(GameTerms.Motion.Attack);
                    if (att != null) temporaryTokens.CombineMTT(att);
                    MultiTypeToken? str = (st as PowerInfoGenerator).YieldMTT(GameTerms.Motion.Strike);
                    if (str != null) temporaryTokens.CombineMTT(str);
                    MultiTypeToken? def = (st as PowerInfoGenerator).YieldMTT(GameTerms.Motion.Defence);
                    if (def != null) temporaryTokens.CombineMTT(def);
                    MultiTypeToken? cha = (st as PowerInfoGenerator).YieldMTT(GameTerms.Motion.Charge);
                    if (cha != null) temporaryTokens.CombineMTT(cha);
                    MultiTypeToken? res = (st as PowerInfoGenerator).YieldMTT(GameTerms.Motion.Rest);
                    if (res != null) temporaryTokens.CombineMTT(res);
                }
            }
        }
        public void ExpectPower2()
        {
        }
        
        public void CalcuateCollision()
        {
            GameTerms.Motion myMotion = GetLastPlayData().motion;
            GameTerms.Motion otherMotion = GameBoard.Instance().FindOpponent(index).GetLastPlayData().motion;
            bool isCollide = false;
            switch (myMotion)
            {
                case GameTerms.Motion.None:
                    switch (otherMotion)
                    {
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
                    switch (otherMotion)
                    {
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
                    switch (otherMotion)
                    {
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
                    switch (otherMotion)
                    {
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Charge:
                            isCollide = true;
                            break;
                    }
                    break;
                case GameTerms.Motion.Charge:
                    switch (otherMotion)
                    {
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
                    switch (otherMotion)
                    {
                        case GameTerms.Motion.Attack:
                        case GameTerms.Motion.Strike:
                        case GameTerms.Motion.Charge:
                            isCollide = true;
                            break;
                    }
                    break;
                case GameTerms.Motion.Avoid:
                    switch (otherMotion)
                    {
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
            Debug.Log(tp + " / " + tp.ToString());
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