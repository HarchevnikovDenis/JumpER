using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private new Rigidbody2D rigidbody;
    private bool isFilled;

    private float jumpForce = 7.5f;
    private bool isEndOfPlatform;
    private bool isJump;

    private Transform platformTransform;
    private Score score;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && !isFilled)
        {
            FillingOut();
        }

        if(Input.GetMouseButtonUp(0) && !isJump &&!isFilled)
        {
            Jump();
            isFilled = true;
            isEndOfPlatform = true;
        }

        if(isFilled && !isEndOfPlatform && !GamestatsManager.isGameOver)
        {
            GoRightSidePlatform(platformTransform);
        }
    }

    //Заполнение слайдера
    private void FillingOut()
    {
        slider.value += Time.deltaTime;
    }

    //Прыжок
    private void Jump()
    {
        rigidbody.velocity = new Vector2(0.0f, jumpForce * slider.value);
        GamestatsManager.speed = 7.5f;
    }

    //Приземление
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            if (GamestatsManager.isInGoldenZone)            //Игрок упал точно в центр платформы
            {
                score.ExtraScore();
            }

            isEndOfPlatform = false;
            platformTransform = collision.transform;
            isJump = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isJump = true;
        }
    }

    private void GoRightSidePlatform(Transform platformTransform)
    {
        if(transform.position.x > platformTransform.position.x + platformTransform.localScale.x)
        {
            isEndOfPlatform = true;
            isFilled = false;
            slider.value = 0.0f;
            GamestatsManager.speed = 0.0f;

            score.AddScore();
        }
    }
}
