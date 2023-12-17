namespace Board
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "BallSprites", menuName = "ScriptableObjects/BallSprites", order = 1)]
    public class BallSpritesSO : ScriptableObject
    {
        public Sprite Ball1_B_Orange;
        public Sprite Ball2_I_Yellow;
        public Sprite Ball3_N_Purple;
        public Sprite Ball4_G_Blue;
        public Sprite Ball5_O_Green;

        public float FreeDaubSpeed = 0.1f;

        public Sprite GetSprite(int num)
        {
            if (num <= 16)
                return Ball1_B_Orange;
            else if (num <= 30)
                return Ball2_I_Yellow;
            else if (num <= 45)
                return Ball3_N_Purple;
            else if (num <= 60)
                return Ball4_G_Blue;
            else
                return Ball5_O_Green;
        }

        public Sprite GetSprite(CardLetters ballType)
        {
            return ballType switch
            {
                CardLetters.B => Ball1_B_Orange,
                CardLetters.I => Ball2_I_Yellow,
                CardLetters.N => Ball3_N_Purple,
                CardLetters.G => Ball4_G_Blue,
                CardLetters.O => Ball5_O_Green,
                _ => throw new System.NotImplementedException()
            };
        }
    }
}