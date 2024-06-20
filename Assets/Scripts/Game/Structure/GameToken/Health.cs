namespace ssm.game.structure{
    public class Health : GameToken
    {
        public Health(float v = 0f) : base(v){
            type = GameTerms.TokenType.Health;
        }
        public override void OnGameStart(Character me, Character other){
            CapHealth(me);
        }
        public override void OnTurnStart(Character me, Character other){
            CapHealth(me);
        }
        private void CapHealth(Character me){
            float maxHealth = me.token.GetGameTokenValue(GameTerms.TokenType.MaxHealth);
            if(value > maxHealth) value = maxHealth;
        }
    }
}