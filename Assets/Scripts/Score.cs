using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Animator perfectLanding;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text bestScore;
    [SerializeField] private GameObject newScoreTitle;
    private Animator scoreAnimator;

    public int score { get; private set; }

    private void Start()
    {
        scoreAnimator = GetComponent<Animator>();
    }

    public void AddScore()
    {
        score++;
        scoreAnimator.SetTrigger("ScoreAdded");
        scoreText.text = score.ToString();
    }

    public void ExtraScore()
    {
        score++;
        perfectLanding.SetTrigger("Perfect");
    }

    public void SetScoreTextInGameOverPanel()
    {
        currentScore.text = score.ToString();
        int best = PlayerPrefs.GetInt("Best_Score", 0);

        if (score > best)  //Установили новый рекорд
        {
            newScoreTitle.SetActive(true);
            bestScore.text = score.ToString();
            PlayerPrefs.SetInt("Best_Score", score);
        }
        else
        {
            newScoreTitle.SetActive(false);
            bestScore.text = best.ToString();
        }
    }
}
