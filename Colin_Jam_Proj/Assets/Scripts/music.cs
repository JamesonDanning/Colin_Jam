using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private static music instance = null;
    public static music Instance
    {
        get { return instance; }
    }
    //private AudioSource _audioSource;
    //bool startedAudio = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        //_audioSource = GetComponent<AudioSource>();
    }

    /*private void Start()
    {
        if (!startedAudio)
        {
            PlayMusic();
            startedAudio = true;
        }
    }*/

    /*public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }*/
}
