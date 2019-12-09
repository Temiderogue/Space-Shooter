using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject ScoreText;
    private Text text;

    private int score = 0;

    public void Start()
    {
        text = ScoreText.GetComponent<Text>();
    }
    public void UpdateScore(int scoreIncrement)
    {
        score += scoreIncrement;
        text.text = "Score = " + score;
    }
}
