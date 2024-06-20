namespace ssm.game.structure{
    public class CollisionWin : GameToken
    {
        public CollisionWin(float v = 0f) : base(v){
            type = GameTerms.TokenType.CollisionWin;
        }
    }
    public class CollisionLose : GameToken
    {
        public CollisionLose(float v = 0f) : base(v){
            type = GameTerms.TokenType.CollisionLose;
        }
    }
    public class NoCollision : GameToken
    {
        public NoCollision(float v = 0f) : base(v){
            type = GameTerms.TokenType.NoCollision;
        }
    }
}