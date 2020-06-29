using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int health;
    Rigidbody2D rb2d;
    public float speed;
    public GameObject self;
    //private float curSpeed;
    //private float maxSpeed;
    public float maxVelocity;
    SpriteRenderer spriteRenderer;
    float horizontal;
    float vertical;
    public Material matWhite;
    private Material matDefault;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //matWhite = Resources.Load("LiberationSans SDF Material", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
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
        if (AxisInput.x > 0)
        {
            self.transform.localScale = new Vector2(-1f, 1f);
        }
        else if (AxisInput.x < 0)
        {
            self.transform.localScale = new Vector2(1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            //Debug.Log("Hit");
            Destroy(collision.gameObject);
            health--;
            spriteRenderer.material = matWhite;
            Invoke("ResetMaterial", .2f);
            if (health <= 0)
            {
                //Game Over stuff
                Debug.Log("Game Over");
            }
        }
    }

    void ResetMaterial()
    {
        spriteRenderer.material = matDefault;
    }
}
