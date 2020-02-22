using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Animator perfectLanding;
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
}
