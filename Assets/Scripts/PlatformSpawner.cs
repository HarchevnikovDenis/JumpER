using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Vector3 startPlatform;
    private Transform lastPlatform;
    private bool isRandomIntervalSelected;
    private float interval;

    private void Start()
    {
        SpawnFirstPlatforms();
    }

    private void SpawnFirstPlatforms()
    {
        while (true)
        {
            interval = Random.Range(12.5f, 25.0f);
            startPlatform.x += interval;

            GameObject platform = Instantiate(platformPrefab, startPlatform, Quaternion.identity);
            platform.transform.localScale = new Vector2(Random.Range(0.75f, 2.0f), platform.transform.localScale.y);

            if (startPlatform.x > 10.0f)
            {
                lastPlatform = platform.transform;
                break;
            }
        }
    }

    private void SpawnRandomSizePrefab()
    {
        GameObject platform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
        platform.transform.localScale = new Vector2(Random.Range(0.75f, 1.5f), platform.transform.localScale.y);

        lastPlatform = platform.transform;
    }

    private void Update()
    {
        if (!isRandomIntervalSelected)
        {
            interval = Random.Range(12.5f, 25.0f);
            isRandomIntervalSelected = true;
        }

        if(transform.position.x - lastPlatform.position.x > interval)
        {
            SpawnRandomSizePrefab();
            isRandomIntervalSelected = false;
        }
    }
}
