using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    GameObject player;
    SpriteRenderer enemySpriteRenderer;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) != 0)
        {
            if(transform.position.x < player.transform.position.x)
            {
                enemySpriteRenderer.flipX = true;
            } else
            {
                enemySpriteRenderer.flipX = false;
            }
            //transform.LookAt(player.transform.position);
            //transform.Rotate(new Vector2(1, 1), Space.Self);
            //transform.Translate(new Vector2(-speed * Time.deltaTime, -speed * Time.deltaTime));
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            //RotateTowards(player.transform.position);
        }
    }

    /*private void RotateTowards(Vector2 target)
    {
        var offset = -180f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }*/
}
