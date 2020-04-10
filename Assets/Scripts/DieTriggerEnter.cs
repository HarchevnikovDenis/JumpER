using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DieTriggerEnter : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gamePlayPanel;

    private Animator cameraAnimator;
    private Score score;
    private GamestatsManager stats;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        score = FindObjectOfType<Score>();
        if (score == null)
            Debug.LogError("Score is null");

        stats = FindObjectOfType<GamestatsManager>();
        if (stats == null)
            Debug.LogError("GamestatsManager is null");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>() && !stats.isGameOver)
        {
            Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();

            if (player == null)
                Debug.LogError("Rigidbody not found");
            else
                DieAnimation(player);

            stats.isGameOver = true;
        }
    }

    //Игрок упал в пропасть
    private void DieAnimation(Rigidbody2D rb)
    {
        stats.isMove = false;
        rb.velocity = new Vector2(0.0f, 5.0f);
        rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
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

        score.SetScoreTextInGameOverPanel();
    }
}
