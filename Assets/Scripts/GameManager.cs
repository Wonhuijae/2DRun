using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;
    public Image HpBar;
    public Image ProgBar;

    private float playTime;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        HpBar.GetComponent<BarController>().Setdefault(Player.GetComponent<UpBtn>().hp);
        ProgBar.GetComponent<BarController>().Setdefault(60f);
        playTime = 0f;
}

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        ProgBar.GetComponent<BarController>().SetCurProg(playTime);
    }
}
