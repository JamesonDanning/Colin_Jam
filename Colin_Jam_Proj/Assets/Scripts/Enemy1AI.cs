using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    GameObject player;
    SpriteRenderer enemySpriteRenderer;
    public int health;
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
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            //RotateTowards(player.transform.position);
        }

        if (health <= 0)
        {
            //Play sound or death anim
            Destroy(gameObject);
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
