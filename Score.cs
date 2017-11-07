using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int score;
    public int currentScore;
    public int scoreModifier;
    public Text scoreText;



	// Use this for initialization
	void Start () {
        score = 0;
        currentScore = score;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void increaseScore(int score)
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

    public void decreaseScore(int score)
    {
        currentScore -= score;
    }


}
