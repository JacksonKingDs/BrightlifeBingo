
namespace Settings
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "GameSettings", menuName = "GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [SerializeField]
        private float daubMeterIncrementSpeed = 2f;

        [SerializeField]
        private int numbersToCall = 25;

        [Space]
        [Header("One board game")]
        public Vector3 OneBoard_B1Position;

        [SerializeField]
        private float oneBoardScale;

        [Space]
        [Header("Two board game")]
        public Vector3 TwoBoard_B1Position;
        public Vector3 TwoBoard_B2Position;

        [SerializeField]
        private float twoBoardScale;

        [Space]
        [Header("Three board game")]
        public Vector3 ThreeBoard_B1Position;
        public Vector3 ThreeBoard_B2Position;
        public Vector3 ThreeBoard_B3Position;

        [SerializeField]
        private float threeBoardScale;

        [Space]
        [Header("Four board game")]
        public Vector3 FourBoard_B1Position;
        public Vector3 FourBoard_B2Position;
        public Vector3 FourBoard_B3Position;
        public Vector3 FourBoard_B4Position;
        [SerializeField]
        private float fourBoardScale;

        private int numberOfBoards = 1;

        //Properties
        public int NumberOfBingoCards
        { 
            get
            {
                return numberOfBoards;
            }
            set
            {
                numberOfBoards = Mathf.Clamp(value, 1, 4);
            }
        }

        public Vector3 OneBoardScale => new Vector3(oneBoardScale, oneBoardScale, oneBoardScale);
        public Vector3 TwoBoardScale => new Vector3(twoBoardScale, twoBoardScale, twoBoardScale);
        public Vector3 ThreeBoardScale => new Vector3(threeBoardScale, threeBoardScale, threeBoardScale);
        public Vector3 FourBoardScale => new Vector3(fourBoardScale, fourBoardScale, fourBoardScale);
        public float DaubMeterIncrementSpeed => daubMeterIncrementSpeed;
    }
}