using System.Collections;
using UnityEngine;

public class testReader : MonoBehaviour
{
    public Texture2D texture;
    bool[,] Tiles = new bool[5, 5];

    void Start()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                //Debug.Log()
                Tiles[x,y] = (int)Mathf.Round(texture.GetPixel(x, y).grayscale) < 0.5f;
            }
        }

        
    }

    void Update()
    {

    }

    private void OnGUI()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                GUI.Label(new Rect(20 + 20 * x, 20 + 20 * y, 50, 20), Tiles[x, y] ? "x" : ".");
            }
        }
    }
}