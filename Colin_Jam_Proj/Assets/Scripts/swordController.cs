using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour
{
    public GameObject player;
    float angle;
    public float speed = 5f;
    private Timer timer;
    //new shit
    // var Parent : Transform;
    //var Obj : Transform;
    public float Radius = 5;
    float Dist;
    Vector3 MousePos;
    Vector3 ScreenMouse;
    Vector3 MouseOffset;

    Animator animator;

    public ParticleSystem splatter;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //_centre = player.transform.position;
        animator = GetComponent<Animator>();
        timer = GameObject.FindGameObjectWithTag("timer").GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);



        //new shit
        MousePos = Input.mousePosition;
        ScreenMouse = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, transform.position.z - Camera.main.transform.position.z));
        MouseOffset = ScreenMouse - player.transform.position;
        transform.position = new Vector3(ScreenMouse.x, ScreenMouse.y);

        Dist = Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y));

        if (Dist > Radius)
        {
            var norm = MouseOffset.normalized;
            transform.position = new Vector3(norm.x * Radius + player.transform.position.x, norm.y * Radius + player.transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit " + collision.gameObject.name + " with sword");
        if (collision.gameObject.tag == "enemy") //Check if sword is hitting enemy
        {
            //timer.incrementBirdsSlain();
            splatter.transform.position = collision.gameObject.transform.position;
            splatter.Play();
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0)) //Check if animation is playing, if it is, base damage off animation
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Test")) //Check current animation and base damage off that if there is an animation
                {
                    //Do damage
                }
            }
            else
            {
             
                collision.gameObject.GetComponent<Enemy1AI>().health -= 1;
                if(collision.gameObject.GetComponent<Enemy1AI>().health <= 0)
                {
                    timer.incrementBirdsSlain();
                }
                else
                {

                    Debug.Log("Push");
                    //try to push living birds back here
                    if (collision.gameObject.GetComponent<Enemy1AI>().enemySpriteRenderer.flipX == true)
                    {
                       
                        //position.x gets minus amount
                        Vector3 targetPosition = collision.gameObject.transform.position + new Vector3(-3f, 0f, 0f);
                        collision.gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, targetPosition, 5 * Time.deltaTime);
                    }
                    else
                    {
                        Vector3 targetPosition = collision.gameObject.transform.position + new Vector3(3f, 0f, 0f);
                        collision.gameObject.transform.position = Vector3.Lerp(collision.gameObject.transform.position, targetPosition, 5 * Time.deltaTime);
                    }
                }
               
            }
        }
    }

   


}




