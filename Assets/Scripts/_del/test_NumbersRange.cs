using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 Total range = 1~75
B: 1~15
I: 16~30
N: 31~45
G: 46~60
O: 61~75
 */


public class test_NumbersRange : MonoBehaviour
{
    public static test_NumbersRange Instance;

    List<List<int>> availableNums = new List<List<int>>();
    int availableCount;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //Intialize 
        availableNums = new List<List<int>>();

        //Initialize range
        for (int col = 0; col < 5; col++) //Column
        {
            availableNums.Add(new List<int>()); //Initialize list
            int start = 1 + col * 15; //Set starting point

            for (int j = 0; j < 15; j++) //Row
            {
                availableNums[col].Add(start + j);
                availableCount++;
            }
        }
    }

    public int GetNumber(out int column) //Pick an available, unpicked number. Pass out the column in which this number is acquired from.
    {
        if (availableCount <= 0)
        {
            column = 0;
            Debug.Log("out of balls");
            return 0;
        }

        while (true)
        {
            column = Random.Range(0, 5);
            if (availableNums[column].Count > 0)
            {
                int index = Random.Range(0, availableNums[column].Count);
                int ballNum = availableNums[column][index];
                availableNums[column].RemoveAt(index);

                availableCount--;

                Debug.Log("acquired number: " + ballNum);
                return ballNum;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int column;
            GetNumber(out column);
        }
    }

    void OnGUI()
    {

        for (int col = 0; col < availableNums.Count; col++)
        {
            //Debug
            string t = col switch
            {
                0 => "B: ",
                1 => "I: ",
                2 => "N: ",
                3 => "G: ",
                4 => "O: ",
                _ => "-"
            };

            for (int n = 0; n < availableNums[col].Count; n++)
            {
                t += "  " + (availableNums[col][n]).ToString();
            }

            GUI.Label(new Rect(20, 20 + 30 * col, 900, 30), t);
        }
    }

}