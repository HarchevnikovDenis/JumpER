using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackgroundCreator : MonoBehaviour
{
    [SerializeField] private List<Color> colors = new List<Color>();

    private void Start()
    {
        Camera camera = Camera.main;
        camera.backgroundColor = colors[Random.Range(0, colors.Count)];
    }
}
