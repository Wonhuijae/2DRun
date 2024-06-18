using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player;
    public Image HpBar;
    public Image ProgBar;
    public GameObject GameOverUI;

    private float playTime;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        initGame();
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().name == "PlayScene")
        {
            HpBar.GetComponent<BarController>().Setdefault(Player.GetComponent<UpBtn>().hp);
            ProgBar.GetComponent<BarController>().Setdefault(60f);
        }
        playTime = 0f;
}

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;
        ProgBar.GetComponent<BarController>().SetCurProg(playTime);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameOver = true;
        GameOverUI.SetActive(true);
    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void GamePause()
    {
        Time.timeScale = 0f;
        Player.GetComponent<UpBtn>().PausedPress();
    }

    public void GameAgain()
    {
        Time.timeScale = 1f;
        Player.GetComponent<UpBtn>().PausedRelease();
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void ReLoad()
    {
        SceneManager.LoadScene(1);
    }

    void initGame()
    {
        Time.timeScale = 1f;
        playTime = 0f;
        isGameOver = false;
    }
}
