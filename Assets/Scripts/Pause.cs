using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject darkScreen;

    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PausePress()
    {
        gm.GamePause();
        darkScreen.SetActive(true);
    }

    public void PauseRelease()
    {
        gm.GameAgain();
        darkScreen.SetActive(false);
    }

    public void BTitlePress()
    {
        gm.LoadTitle();
    }

    public void ExitPress()
    {
        gm.GameExit();
    }

    public void Retry()
    {
        gm.ReLoad();
    }
}
