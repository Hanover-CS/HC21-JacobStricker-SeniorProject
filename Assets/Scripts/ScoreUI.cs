using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMesh scoreText;

    void start()
    {
        //sets starting score to 0
        updateScore(0);
    }

    void updateScore(int score)
    {
        scoreText.text = "SCORE: " + score;
    }

}
