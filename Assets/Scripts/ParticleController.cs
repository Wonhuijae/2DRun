using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    ParticleSystem bubble;

    // Start is called before the first frame update
    void Start()
    {
        bubble = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 10f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if( other.tag =="Player")
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
        }
    }
}
