using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    [SerializeField] private float speed;
    private GamestatsManager stats;

    private void Start()
    {
        stats = FindObjectOfType<GamestatsManager>();    
    }

    private void Update()
    {
        if (!stats.isMove) return;

        transform.Translate(-Vector2.right * Time.deltaTime * speed);

        if (transform.position.x < -25.0f)
            Destroy(gameObject);
    }
}
