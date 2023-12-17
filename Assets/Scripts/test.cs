using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 Future featues
- achievements  for each shape
- 4 boards
- all difficult patterns https://chipy.com/academy/bingo/bingo-patterns

 
 
 
 
 
 
 
 
 
 
 
 
 
 */

[System.Serializable]
public class CardArray
{
    public int[] hi;
}


public class test : MonoBehaviour
{
    List<int> nums = new List<int>();

    [SerializeField]
    List<List<int>> t1;

    [SerializeField]
    int[][] t2;

    [SerializeField]
    int[,] t3;

    [SerializeField]
    int hi;

    [SerializeField]
    List<CardArray> hi2;

    void Start()
    {




    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nums.Add(Random.Range(0, 111));
            if (nums.Count > 5)
            {
                nums.RemoveAt(0);
            }
        }
    }

    public void OnGUI()
    {
        string s = "";
        for (int i = 0; i < nums.Count; i++)
        {
            s += " " + nums[i].ToString();
        }
        GUI.Label(new Rect(20, 20, 999, 30), "nums: " + s);
    }

    public void ButtonClicked()
    {
        Debug.Log("Clicked");
    }

    void PrintBINGONumbers()
    {
        for (int i = 0; i < 5; i++)
        {
            string t = i switch
            {
                0 => "B: ",
                1 => "I: ",
                2 => "N: ",
                3 => "G: ",
                4 => "O: ",
                _ => "-"
            };

            //start: i*15 end = start + 15
            int start = 1 + i * 15;
            int end = start + 15;

            for (int j = 0; j < 15; j++)
            {
                t += "  " + (start + j).ToString();
            }

            Debug.Log(t);
        }
    }
}
