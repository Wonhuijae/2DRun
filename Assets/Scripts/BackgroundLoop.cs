using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundLoop : MonoBehaviour
{
    private float width;
    private float sizeX;
    private float pivot;

    // Start is called before the first frame update
    void Awake()
    {
        BoxCollider2D bgCollider = GetComponent<BoxCollider2D>();

        width = bgCollider.size.x;
        sizeX = transform.localScale.x * 2;

        pivot = width + sizeX;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -pivot + 0.2 * width)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(pivot*2, 0);
        transform.position = (Vector2) transform.position + offset;
    }
}
