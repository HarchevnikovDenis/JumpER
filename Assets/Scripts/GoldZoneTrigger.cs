using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>())
        {
            GamestatsManager.isInGoldenZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerInput>())
        {
            GamestatsManager.isInGoldenZone = false;
        }
    }
}
