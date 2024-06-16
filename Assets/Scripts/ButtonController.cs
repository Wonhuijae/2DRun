using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button me;

    private bool isPressed = false;
    private Color originalColor;
    private Color pressedColor;
    

    // Start is called before the first frame update
    void Start()
    {
        originalColor = gameObject.GetComponent<Image>().color;
        pressedColor = me.colors.pressedColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            gameObject.GetComponent<Image>().color = originalColor * pressedColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = originalColor;
        }
    }

    public void ChangeButtonState(bool _isPressed)
    {
        isPressed = _isPressed;
    }
}
