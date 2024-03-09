using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaController : MonoBehaviour
{
    private Rigidbody2D myrigidbody2d;
    public float velocidadBala = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody2d.velocity = new Vector2(velocidadBala, myrigidbody2d.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigo")) { 
            Destroy(collision.gameObject);
        }
        //else if (collision.CompareTag(""))
        //{
        //    Destroy(collision.gameObject);
        //}
    }
}
