using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordController : MonoBehaviour
{
    public GameObject player;
    float angle;
    public float speed = 5f;

    //new shit
   // var Parent : Transform;
    //var Obj : Transform;
    public float Radius = 5;
    float Dist;
    Vector3 MousePos;
    Vector3 ScreenMouse;
    Vector3 MouseOffset;

    // Start is called before the first frame update
    void Start()
    {
        //_centre = player.transform.position;
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
}




