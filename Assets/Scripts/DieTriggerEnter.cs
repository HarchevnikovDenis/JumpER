using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>() && !SpeedManager.isGameOver)
        {
            Rigidbody2D player = other.gameObject.GetComponent<Rigidbody2D>();

            if (player == null)
                Debug.LogError("Rigidbody not found");
            else
                DieAnimation(player);

            SpeedManager.isGameOver = true;
        }
    }

    //Игрок упал в пропасть
    private void DieAnimation(Rigidbody2D rb)
    {
        SpeedManager.speed = 0.0f;
        rb.velocity = new Vector2(0.0f, 5.0f);
        rb.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(rb.gameObject, 5.0f);
    }
}
