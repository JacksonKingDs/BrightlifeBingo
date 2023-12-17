//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BingoButtons : MonoBehaviour
//{
//    const int BUTTON_COUNT = 5;
//    const float MARGIN = 10;
//    const float BUTTON_WIDTH = 50;
//    const float SPACING = BUTTON_WIDTH + MARGIN;

//    public GameObject pf_Button;
//    public Canvas canvas;

//    List<GameObject> buttons;


//    void Awake()
//    {
//        //Initialize
//        buttons = new List<GameObject>();
//        GameObject b = Instantiate(pf_Button, new Vector2(0, 0), Quaternion.identity, canvas.transform);

//    }

//    void Update()
//    {

//    }

//    public void BuildButtons()
//    {
//        //Screen center
//        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

//        float offset = (BUTTON_WIDTH  * BUTTON_COUNT + (BUTTON_COUNT - 1) * MARGIN) / 2f; //Offset from center of screen
//        Vector2 startPos = new Vector2(screenCenter.x - offset, screenCenter.y - offset);

//        for (int x = 0; x < BUTTON_COUNT; x++)
//        {
//            for (int y = 0; y < BUTTON_COUNT; y++)
//            {
//                float posX = -startPos.x + x * SPACING;
//                float posY = -startPos.y + y * SPACING;

//                GameObject b = Instantiate(pf_Button, new Vector2(posX, posY), Quaternion.identity, canvas.transform);
//                buttons.Add(b);
//            }
//        }
//    }
//}