using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy1AI : MonoBehaviour
{
    GameObject player;
    public SpriteRenderer enemySpriteRenderer;
    public int health;
    public float speed;
    private AudioSource audioSource;
    CameraShake cameraShake;
    public Material matWhite;
    private Material matDefault;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = this.GetComponent<AudioSource>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogError("No CameraShake script found on camera object");
        }

        matDefault = enemySpriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (Vector2.Distance(transform.position, player.transform.position) != 0)
            {
                if (transform.position.x < player.transform.position.x)
                {
                    enemySpriteRenderer.flipX = true;
                }
                else
                {
                    enemySpriteRenderer.flipX = false;
                }
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                //RotateTowards(player.transform.position);
            }
        }


        if (health <= 0)
        {
            //Play sound or death anim
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            cameraShake.Shake(.002f, .01f);
            transform.position = Camera.main.ViewportToWorldPoint(new Vector2(2, 2));
            Destroy(gameObject, audioSource.clip.length);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "sword")
        {
            enemySpriteRenderer.material = matWhite;
            Invoke("ResetMaterial", .2f);
        }
    }


    void ResetMaterial()
    {
        enemySpriteRenderer.material = matDefault;
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
