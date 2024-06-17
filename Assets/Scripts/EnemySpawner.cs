using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Reef;
    public GameObject Fish;
    public GameObject Bubble;

    public float spawnTime;
    public float spawnMin = 1f;
    public float spawnMax = 4f;
    public int count = 3;

    private GameObject[] Reefs;
    private GameObject[] Fishes;
    private GameObject[] Bubbles;

    private Vector2 FirstPos = new Vector2(-25, -25);
    private float lastSpawn = 0f;
    private float TimeBetweenSpawn = 0f;
    private float yMin = -4f;
    private float yMax = 4f;
    private float xPos = 20f;

    private int curIdx = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Reefs = new GameObject[count];
        Fishes = new GameObject[count];
        Bubbles = new GameObject[count];

        FirstSpawn(Reefs, Reef);
        FirstSpawn(Fishes, Fish);
        FirstSpawn(Bubbles, Bubble);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver()) return;

        if(Time.time >= lastSpawn+TimeBetweenSpawn)
        {
            lastSpawn = Time.time;

            TimeBetweenSpawn = Random.Range(spawnMin, spawnMax);

            PlaySpawn(WhatSpawn());
        }
    }

    void FirstSpawn(GameObject[] _Enemy, GameObject _Prefab)
    {
        for(int i=0;i<count; i++)
        {
            _Enemy[i] = Instantiate(_Prefab, FirstPos, Quaternion.identity);
        }
    }

    void PlaySpawn(GameObject[] _Enemy)
    {
        float spawnPos;

        spawnPos = WherePos(_Enemy);

        _Enemy[curIdx++].transform.position = new Vector2(xPos, spawnPos);
        if (curIdx >= count) curIdx = 0;
    }

    GameObject[] WhatSpawn()
    {
        int choice = Random.Range(0, count);

        if (choice == 0) return Reefs;
        else if(choice == 1) return Fishes;
        else return Bubbles;
    }

    float WherePos(GameObject[] _Enemy)
    {
        if (_Enemy == Fishes) return Random.Range(yMin, yMax);
        else if (_Enemy == Bubbles) return 0f;
        else return -4;
    }
}
