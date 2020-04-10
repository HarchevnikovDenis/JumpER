using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldZoneTrigger : MonoBehaviour
{
    private GamestatsManager stats;

    private void Start()
    {
        stats = FindObjectOfType<GamestatsManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>())
        {
            stats.isInGoldenZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>())
        {
            stats.isInGoldenZone = false;
        }
    }
}
