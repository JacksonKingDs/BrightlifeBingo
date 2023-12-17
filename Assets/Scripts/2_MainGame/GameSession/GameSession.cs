namespace MainGame
{
    using System.Collections.Generic;
    using UnityEngine;
    using Settings;

    public class GameSession
    {
        private GameSettings settings;

        private Board[] board;

        public List<int> calledNumbers = new List<int>();

        public GameSession(Board[] board, GameSettings settings, MatchDetection matchDetection)
        {
            //Cache reference
            this.settings = settings;
            this.board = board;

            //Setup scene
            PositionBoards(settings.NumberOfBingoCards);

            for (int i = 0; i < settings.NumberOfBingoCards; i++)
            {
                board[i].Init(settings, matchDetection);
            }
        }

        private void PositionBoards(int numberOfBoards)
        {
            if (numberOfBoards == 1)
            {
                SetBoardTransform(board[0].transform, settings.OneBoard_B1Position, settings.OneBoardScale);
            }
            else if (numberOfBoards == 2)
            {
                SetBoardTransform(board[0].transform, settings.TwoBoard_B1Position, settings.TwoBoardScale);
                SetBoardTransform(board[1].transform, settings.TwoBoard_B2Position, settings.TwoBoardScale);
            }
            else if (numberOfBoards == 3)
            {
                SetBoardTransform(board[0].transform, settings.ThreeBoard_B1Position, settings.ThreeBoardScale);
                SetBoardTransform(board[1].transform, settings.ThreeBoard_B2Position, settings.ThreeBoardScale);
                SetBoardTransform(board[2].transform, settings.ThreeBoard_B3Position, settings.ThreeBoardScale);
            }
            else if (numberOfBoards == 4)
            {
                SetBoardTransform(board[0].transform, settings.FourBoard_B1Position, settings.FourBoardScale);
                SetBoardTransform(board[1].transform, settings.FourBoard_B2Position, settings.FourBoardScale);
                SetBoardTransform(board[2].transform, settings.FourBoard_B3Position, settings.FourBoardScale);
                SetBoardTransform(board[3].transform, settings.FourBoard_B4Position, settings.FourBoardScale);
            }

            for (int i = 0; i < board.Length; i++)
            {
                board[i].gameObject.SetActive((i < numberOfBoards) ? true : false);
            }
        }

        private void SetBoardTransform(Transform t, Vector3 position, Vector3 scale)
        {
            t.localPosition = position;
            t.localScale = scale;
        }
    }
}