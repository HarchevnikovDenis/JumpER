using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject buildingSprite;
    [SerializeField] private float distanceToSpawn;
    [SerializeField] private List<Color> colors = new List<Color>();

    [SerializeField] private Vector3 firstPoint;
    private Transform lastBuilding;

    private void Start()
    {
        CreateFirstBuildings();
    }

    private void Update()
    {
        if(transform.position.x - lastBuilding.position.x > distanceToSpawn)
        {
            Vector3 nextPoint = new Vector3(lastBuilding.transform.position.x + distanceToSpawn, transform.position.y, transform.position.z);
            CreateBuilding(nextPoint);
        }
    }


    private void CreateFirstBuildings()
    {
        float currentX = firstPoint.x;
        while(transform.position.x - currentX > distanceToSpawn)
        {
            Vector3 nextPosition = new Vector3(currentX, firstPoint.y, firstPoint.z);
            CreateBuilding(nextPosition);

            currentX += distanceToSpawn;
        }
    }

    private void CreateBuilding(Vector3 point)
    {
        GameObject building = Instantiate(buildingSprite, point, Quaternion.identity);
        lastBuilding = building.transform;

        building.transform.localScale = new Vector3(building.transform.localScale.x,
                                                    Random.Range(2.0f, 6.0f),
                                                    building.transform.localScale.z);
        if (building.GetComponent<SpriteRenderer>() != null)
        {
            building.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Count)];
        }
        else
        {
            Debug.LogError("SpriteRenderer is null"); 
        }

        building.transform.SetParent(transform);
    }
}
