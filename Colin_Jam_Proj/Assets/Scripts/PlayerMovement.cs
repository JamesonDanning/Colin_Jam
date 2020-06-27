using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    public GameObject self;
    //private float curSpeed;
    //private float maxSpeed;
    public float maxVelocity;

    float horizontal;
    float vertical;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 AxisInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        

        rb2d.AddForce(AxisInput * speed, ForceMode2D.Impulse); 

        //limits velocity
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxVelocity);

        //slows bird down when no input
        if (AxisInput == Vector2.zero)
        {            
            rb2d.velocity /= new Vector2(1.05f, 1.05f);         
        }

        if(AxisInput.x > 0)
        {
            self.transform.localScale = new Vector2(-4f, 4f);
        }
        else if(AxisInput.x < 0)
        {
            self.transform.localScale = new Vector2(4f, 4f);
        }


    }
}
