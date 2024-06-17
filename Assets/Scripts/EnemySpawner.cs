using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Reef;
    public GameObject[] Fish;
    public GameObject[] Bubble;

    public float spawnTime;
    public float spawnMin = 1f;
    public float spawnMax = 4f;

    // Start is called before the first frame update
    void Awake()
    {
        Reef = new GameObject[4]; // Å©±â
        Fish = new GameObject[4]; // »ö
        Bubble = new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
