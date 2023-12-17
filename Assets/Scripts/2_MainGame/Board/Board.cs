namespace MainGame
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using Settings;
    using Audio;

    public class Board : MonoBehaviour
    {
        /// <summary>
        /// The card gameobjects, associated with this board 
        /// (There can be multiple boards).
        /// </summary>
        [SerializeField] 
        private SceneCardsReference cardsReferencer;

        private GameSettings settings;

        private Sfx sfx;

        private MatchDetection matchDetection;

        public List<int> alreadyAssignedNumbers = new List<int>();

        //Status
        public Card[,] cards;
        public bool[,] markedPositions;

        #region Init

        public void Init(GameSettings settings, MatchDetection matchDetection)
        {
            this.settings = settings;
            this.matchDetection = matchDetection;
            sfx = Sfx.Instance;

            alreadyAssignedNumbers = new List<int>();

            markedPositions = new bool[5, 5];
            for (int i = 0; i < markedPositions.GetLength(0); i++)
            {
                for (int j = 0; j < markedPositions.GetLength(1); j++)
                {
                    markedPositions[i, j] = false;
                }
            }

            InitializeCardValue();
        }

        #endregion

        #region Cards initialization

        private void InitializeCardValue()
        {
            //Loop through all cards and give each a random starting number.
            cards = cardsReferencer.GetCardArray();
            int x, y;
            int columns = cards.GetLength(0);
            int rows = cards.GetLength(1);

            for (x = 0; x < columns; x++)
            {
                for (y = 0; y < rows; y++)
                {
                    int assignedNum = GenerateRandomNumberForCard(cards[x, y].Letter);
                    //Debug.Log("x " + x + ", y " + y + ", columns " + columns + ", rows " + rows);
                    cards[x, y].Init(this, x, y, assignedNum);
                }
            }
        }

        private int GenerateRandomNumberForCard(CardLetters letter)
        {
            int assignNum;
            do
            {
                assignNum = Util.GetRandomStartNumber(letter);
            }
            while (alreadyAssignedNumbers.Contains(assignNum));

            alreadyAssignedNumbers.Add(assignNum);
            return assignNum;
        }
        #endregion

        public void ClickedOnCard(Card card)
        {
            card.MarkCard();
            sfx.Play_UI_Confirm();
            markedPositions[card.X, card.Y] = true;
        }

        public void BingoCheck()
        {
            if (matchDetection == false)
            {
                matchDetection = GameManager.Instance.MatchDetector;
            }
            matchDetection.CheckMatch(markedPositions);
        }

        //public void MatchFound(Pattern pattern, BoardManager board)
        //{
        //    Debug.Log("Bingo Match found!  " + pattern.PatternName);
        //    score += pattern.Points;
        //    bingoCounts++;
        //    uiM.SetScore(score);
        //}
    }
}