using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    private float defaultValue;
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
    public void Setdefault(float _defaultValue)
    {
        defaultValue = _defaultValue;
    }

    public void SetCurHP(float _curValue)
    {
        if (_curValue <= 0)
        {
            gm.GameOver();
            return;
        }

        transform.localScale = new Vector3(1, _curValue/ defaultValue, 0);
    }

    public void SetCurProg(float _curValue)
    {
        if (_curValue > defaultValue)
        {
            gm.SetChest();
            return;
        }
        transform.localScale = new Vector3(_curValue / defaultValue, 1, 0);
    }
}
