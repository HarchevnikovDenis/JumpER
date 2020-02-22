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
            interval = Random.Range(6.0f, 24.0f);
            startPlatform.x += interval;

            GameObject platform = Instantiate(platformPrefab, startPlatform, Quaternion.identity);

            float scaleFactor = Random.Range(1.0f, 2.0f);
            ResetGoldenZoneDefaultSize(platform, scaleFactor);
            platform.transform.localScale = new Vector2(scaleFactor, platform.transform.localScale.y);

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
        float scaleFactor = Random.Range(1.0f, 2.0f);
        platform.transform.localScale = new Vector2(scaleFactor, platform.transform.localScale.y);
        ResetGoldenZoneDefaultSize(platform, scaleFactor);

        lastPlatform = platform.transform;
    }

    private void ResetGoldenZoneDefaultSize(GameObject platform, float factor)
    {
        Transform goldenZoneInPlatformPrefab = platform.transform.GetChild(0);
        goldenZoneInPlatformPrefab.localScale = new Vector2(goldenZoneInPlatformPrefab.localScale.x / factor, goldenZoneInPlatformPrefab.localScale.y);
    }

    private void Update()
    {
        if (!isRandomIntervalSelected)
        {
            interval = Random.Range(6.0f, 24.0f);
            isRandomIntervalSelected = true;
        }

        if(transform.position.x - lastPlatform.position.x > interval)
        {
            SpawnRandomSizePrefab();
            isRandomIntervalSelected = false;
        }
    }
}
