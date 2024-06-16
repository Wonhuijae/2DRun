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

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Touch");
        if(other.tag == "Player")
        {
            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -10));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("TouchBottom");
        if (collision.gameObject.tag == "Player")
        { 
            collision.gameObject.GetComponent<UpBtn>().Flooding();
        }
    }
}
