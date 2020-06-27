using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float force;
    public float maxSpeed;

    float horizontal;
    float vertical;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
       

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x = position.x + force * horizontal;
        position.y = position.y + force * vertical;
        transform.position = position;
    }
}
