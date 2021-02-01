using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreUIStub : MonoBehaviour
{
    public int currentScore;

    void start()
    {
        currentScore = -1;
    }
    void updateScore(int score)
    {
        currentScore = score;
    }
}
