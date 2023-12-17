namespace MainGame
{
    using UnityEngine;

    public class SceneCardsReference : MonoBehaviour
    {
        /// <summary>
        /// A class used to help with exposing a 2D array inside the inspector, 
        /// so we can reference the Cards placed in the scene.
        /// </summary>
        [System.Serializable]
        public class CardArray
        {
            public Card[] Column;
        }

        [SerializeField]
        private CardArray[] cards;

        /// <summary>
        /// Remap collection to a cleaner 2D array so we can access a carb via 
        /// cards[x,y] instad of card[x].column[y]
        /// </summary>
        public Card[,] GetCardArray ()
        {
            int XColumns = cards[0].Column.Length;
            int YRows = cards.Length;
            Card[,] remappedCards = new Card[XColumns,YRows];

            for (int x = 0; x < XColumns; x++)
            {
                for (int y = 0; y < YRows; y++)
                {
                    remappedCards[x,y] = cards[x].Column[y];
                    //Debug.Log("Card x=" + x + " y=" + y + " is " + remappedCards[x,y]);
                }
            }

            return remappedCards;
        }
    }
}