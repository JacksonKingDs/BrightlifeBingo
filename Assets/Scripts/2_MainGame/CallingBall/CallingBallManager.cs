namespace MainGame.CallingBall
{
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Caller is the ball that appears at the top of the screen.
    /// </summary>
    public class CallingBallManager : MonoBehaviour
    {
        public static CallingBallManager Instance;

        [SerializeField] 
        private GameObject ballPrefab;

        [SerializeField] 
        private RectTransform parentTransform;

        /// <summary>
        /// The horizontal set of positions in the calling row at the top of screen.
        /// </summary>
        [SerializeField] 
        private RectTransform[] callRowPositions;

        /// <summary>
        /// All the numbers that can be called
        /// </summary>
        private List<List<int>>  callableNums = new List<List<int>>()
            {
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15},
                new List<int> { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30},
                new List<int> { 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 },
                new List<int> { 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 },
                new List<int> { 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75 }
            };

        private List<CallingBall> spawnedBalls;

        /// <summary>
        /// Number of bingo cards are called in a game before the game ends.
        /// </summary>
        private const int MaxBallsCount = 15;

        #region MonoBehavior

        private void Awake()
        {
            Instance = this;

            spawnedBalls = new List<CallingBall>();
        }

        private void Start()
        {
        }

        #endregion

        #region Public

        public Vector2 GetCallRowPosition(int index)
        {
            if (callRowPositions.Length > index)
            {
                return callRowPositions[index].anchoredPosition;
            }
            return callRowPositions[callRowPositions.Length - 1].anchoredPosition;
        }

        #endregion

        #region Private

        private void ShuffleSpawnedBallPositions()
        {
            foreach (var i in spawnedBalls)
            {
            }

            if (spawnedBalls.Count > 5)
            {
                //spawnedCallerCards[0].PlayClearAnimation();
                spawnedBalls.RemoveAt(0);
            }
        }

        private int GetNumber()
        {
            while (true)
            {
                int column = Random.Range(0, callableNums.Count);
                if (callableNums[column].Count > 0)
                {
                    int index = Random.Range(0, callableNums[column].Count);
                    int ballNum = callableNums[column][index];
                    callableNums[column].RemoveAt(index);

                    return ballNum;
                }
            }
        }

        #endregion

        //void OnGUI() //Visualization
        //{
        //    for (int col = 0; col < callableNums.Count; col++)
        //    {
        //        //Debug
        //        string t = col switch
        //        {
        //            0 => "B: ",
        //            1 => "I: ",
        //            2 => "N: ",
        //            3 => "G: ",
        //            4 => "O: ",
        //            _ => "-"
        //        };

        //        for (int n = 0; n < callableNums[col].Count; n++)
        //        {
        //            t += "  " + (callableNums[col][n]).ToString();
        //        }

        //        GUI.Label(new Rect(20, 20 + 30 * col, 900, 30), t);
        //    }
        //}
    }
}