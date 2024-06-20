namespace ssm.game.structure{
    public class MaxHealth : GameToken
    {
        public MaxHealth(float v = 0f) : base(v){
            type = GameTerms.TokenType.MaxHealth;
        }
    }
}