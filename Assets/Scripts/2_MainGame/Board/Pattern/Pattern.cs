namespace MainGame
{

    using UnityEngine;
    using System.Collections.Generic;

    [CreateAssetMenu(fileName = "Pattern", menuName = "ScriptableObject/Pattern", order = 0)]
    public class Pattern : ScriptableObject
    {
        public Texture2D[] Maps;
        public string PatternName;
        public int Points;

        private bool matchFound;
        private bool[][,] pixelMaps;

        public bool MatchFound => matchFound;

        public void Init()
        {
            matchFound = false;
            UnpackPixel();
        }

        private void UnpackPixel()
        {
            pixelMaps = new bool[Maps.Length][,];
            for (int i = 0; i < Maps.Length; i++)
            {
                pixelMaps[i] = new bool[5, 5];

                for (int x = 0; x < 5; x++)
                {
                    for (int y = 0; y < 5; y++)
                    //for (int y = 5; y >=0 ; y--)
                    {
                        //If the pixel is a black pixel (we have to flip the picture upside down)
                        if ((int)Mathf.Round(Maps[i].GetPixel(x, 4 - y).grayscale) < 0.5f)
                        {
                            pixelMaps[i][x, y] = true;
                        }
                    }
                }
            }
        }

        public bool CheckForMatch(bool[,] markedPositions)
        {
            //Loop through all the unpacked pixel map (each pixel map is based on a match pattern variation)
            foreach (var map in pixelMaps)
            {
                if (CheckForMatch(map, markedPositions))
                {
                    matchFound = true;
                    return true;
                }
            }

            return false;
        }

        private bool CheckForMatch(bool[,] map, bool[,] markedDaubs)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    //If the map pixel is true and but is not marked on board, then it's not a match
                    if (map[x, y] && !markedDaubs[x, y])
                        return false;
                }
            }

            return true;
        }
    }

}