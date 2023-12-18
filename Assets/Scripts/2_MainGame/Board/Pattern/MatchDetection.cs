using System.Collections;
using UnityEngine;

/*
 Line
2 line
full house (all clear)
4 corners
outside edge
letter H
number 7
Arrow

clover leaf (+ shape clear)

diamond

 */


namespace MainGame
{
    public class MatchDetection : MonoBehaviour
    {
        public static MatchDetection Instance;

        public Pattern[] Patterns;

        private GameplayMB gameplay;

        public void Init(GameplayMB gameplay)
        {
            Instance = this;

            if (Patterns == null || Patterns.Length < 1)
            {
                Debug.LogError("No patterns loaded");
                return;
            }

            foreach (var p in Patterns)
            {
                p.Init();
            }
        }

        public bool CheckMatch(bool[,] markedBoard)
        {
            foreach (Pattern p in Patterns)
            {
                if (!p.MatchFound)
                {
                    if (p.CheckForMatch(markedBoard))
                    {
                        Debug.Log("Bingo! " + p.name);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}