using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт для постоянного нахождения триггера под игроком
public class DieTriggerFollowToPlayer : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerInput>().transform;
    }

    private void Update()
    {
        if(player != null)
            TakeAPositionUnderThePlayer();
    }

    private void TakeAPositionUnderThePlayer()
    {
        if (transform.position.x != player.position.x)
            transform.position = new Vector2(player.position.x, transform.position.y);
    }
}
