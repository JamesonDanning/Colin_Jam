using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(gameObject.tag == "play")
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if(gameObject.tag == "quit")
        {
            Debug.Log("quit");
        }
    }

    private void OnMouseOver()
    {
        gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1f);
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
