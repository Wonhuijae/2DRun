using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Reef;
    public GameObject Fish;
    public GameObject Bubble;
    public GameObject Potion;

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

        if (Time.time >= lastSpawn + TimeBetweenSpawn)
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

    void PlaySpawn(int _spawnNo)
    {
        float spawnPos = WherePos(_spawnNo);

        if (_spawnNo == 0) spawnFish(spawnPos);
        else if (_spawnNo == 1) spawnReef(spawnPos);
        else spawnBubble(spawnPos);
    }

    int WhatSpawn()
    {
        int choice = Random.Range(0, count);

        return choice;
    }

    float WherePos(int _spawnNo)
    {
        if (_spawnNo == 0) return Random.Range(yMin, yMax);
        else if (_spawnNo == 2) return 0f;
        else return -4;
    }

    void spawnFish(float _spownY) // 0
    {
        float RandomR = Random.Range(0f,  1f);
        float RandomG = Random.Range(0f, 1f);
        float RandomB = Random.Range(0f, 1f);

        Fishes[curIdx].transform.position = new Vector2(xPos, _spownY);
        Fishes[curIdx].GetComponent<SpriteRenderer>().color = new Color(RandomR , RandomG , RandomB , 1);


        curIdx++;
        if (curIdx >= count) curIdx = 0;
    }

    void spawnReef(float _spownY) // 1
    {
        int scaleValue = Random.Range(4, 7);

        Reefs[curIdx].transform.position = new Vector2(xPos, _spownY);
        Reefs[curIdx].transform.localScale = new Vector2(5, scaleValue); //크기
        curIdx++;
        if (curIdx >= count) curIdx = 0;
    }
    void spawnBubble(float _spownY) //2
    {
        Bubbles[curIdx++].transform.position = new Vector2(xPos, _spownY);
        if (curIdx >= count) curIdx = 0;
    }

    public void spawnHeal()
    {
        GameObject o = Instantiate(Potion, new Vector2(xPos, -3f), Quaternion.identity);
        Destroy(o, 5f);
    }
}
