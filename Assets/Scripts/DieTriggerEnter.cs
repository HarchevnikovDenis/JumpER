using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePlayPanel;

    [SerializeField] private Text currentScore;
    [SerializeField] private Text bestScore;
    [SerializeField] private GameObject newScoreTitle;

    private Animator cameraAnimator;
    private Score score;

    private void Start()
    {
        PlayerPrefs.DeleteAll();

        score = FindObjectOfType<Score>().GetComponent<Score>();
        if (score == null)
            Debug.LogError("Score is null");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>() && !GamestatsManager.isGameOver)
        {
            Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();

            if (player == null)
                Debug.LogError("Rigidbody not found");
            else
                DieAnimation(player);

            GamestatsManager.isGameOver = true;
        }
    }

    //Игрок упал в пропасть
    private void DieAnimation(Rigidbody2D rb)
    {
        GamestatsManager.speed = 0.0f;
        rb.velocity = new Vector2(0.0f, 5.0f);
        rb.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        Destroy(rb.gameObject, 5.0f);

        GameOver();
    }

    //Отображение всех UI и встряска камеры
    private void GameOver()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
        cameraAnimator.SetTrigger("Shake");

        StartCoroutine(ShowMenu());
    }

    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2.5f);
        gamePlayPanel.SetActive(false);
        gameOverPanel.SetActive(true);

        SetScoreTextInGameOverPanel();
    }

    private void SetScoreTextInGameOverPanel()
    {
        currentScore.text = score.score.ToString();
        int best = PlayerPrefs.GetInt("Best_Score", 0);

        if(score.score > best)  //Установили новый рекорд
        {
            newScoreTitle.SetActive(true);
            bestScore.text = score.score.ToString();
        }
        else
        {
            newScoreTitle.SetActive(false);
            bestScore.text = best.ToString();
        }
    }
}
