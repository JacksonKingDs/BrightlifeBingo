using System.Collections;
using UnityEngine;

public static class Util
{

    /*
 Total range = 1~75
B: 1~15
I: 16~30
N: 31~45
G: 46~60
O: 61~75
 */
    public static int GetRandomStartNumber(CardLetters types)
    {
        return types switch
        {
            CardLetters.B => Random.Range(1,15),
            CardLetters.I => Random.Range(16,30),
            CardLetters.N => Random.Range(31,45),
            CardLetters.G => Random.Range(46,60),
            CardLetters.O => Random.Range(61, 75),
            _ => -1
        };
    }

    public static CardLetters GetLetterType(int num)
    {
        if (num <= 15)
        {
            return CardLetters.B;
        }
        if (num <= 30)
        {
            return CardLetters.I;
        }
        if (num <= 45)
        {
            return CardLetters.N;
        }
        if (num <= 60)
        {
            return CardLetters.G;
        }
        else
            return CardLetters.N;
    }
}