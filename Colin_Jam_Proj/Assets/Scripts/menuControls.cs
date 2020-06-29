using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControls : MonoBehaviour
{
    private AudioSource audioSource;
    AudioClip clip;
    bool hasExited = true;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        clip = audioSource.clip;
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
        if (hasExited == true)
        {
            audioSource.PlayOneShot(clip);
            hasExited = false;
        }

    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        hasExited = true;
       // audioSource.Stop();
    }
}
