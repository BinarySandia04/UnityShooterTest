using UnityEngine;
using TMPro;
using System;

public class Scoretest : MonoBehaviour {

    private int actualScore = 0;

    private int updatedScore = 0;

    public void addScore(int points)
    {
        actualScore += points;
    }

    void Update()
    {
        if(updatedScore < actualScore)
        {
            updatedScore++;
            
        }
        if (updatedScore < actualScore)
        {
            updatedScore++;

        }
        if (updatedScore < actualScore)
        {
            updatedScore++;

        }
        if (updatedScore < actualScore)
        {
            updatedScore++;

        }
        string s = "";
        for(int i = 0; i < (6 - IntLength(updatedScore)); i++)
        {
            s = s + '0';
        }
        GetComponent<TextMeshProUGUI>().text = "Score: " + s + updatedScore;
    }

    public static int IntLength(int i)
    {
        if (i < 0)
            throw new ArgumentOutOfRangeException();
        if (i == 0)
            return 1;
        return (int)Math.Floor(Math.Log10(i)) + 1;
    }

}
