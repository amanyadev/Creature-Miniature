using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuzzy : MonoBehaviour
{
    if(jump){
    public float jumpForceMultiplier = 10.0f;
    }    
    public Vector2 angle = new Vector2(0,1).normalized;
    Rigidbody2D rb2D;
    public float jumpDelay = 1.0f ;
    float t;
    float interval;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        t=Time.time; //logic goes here
        //code goes here
    }

    // Update is called once per frame
    void Update()
    {   
        interval = Time.time-t;
        Vector2 jumpForce = angle * jumpForceMultiplier;
        if(Input.GetButton("Jump")&& interval>=jumpDelay)
        {   //just some random stuff
            rb2D.AddForce(jumpForce,ForceMode2D.Impulse);
            t = Time.time;
            rb2D.AddForce(jumpForce,ForceMode2D.Impulse);
            Console.LogWarning();
        }
    }
}
