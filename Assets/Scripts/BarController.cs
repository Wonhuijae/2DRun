using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarController : MonoBehaviour
{
    private float defaultValue;

    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.localScale = new Vector3(1, _curValue/ defaultValue, 0);
    }

    public void SetCurProg(float _curValue)
    {
        transform.localScale = new Vector3(_curValue / defaultValue, 1, 0);
    }
}
