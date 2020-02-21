using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int score;

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
