using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int birdsSlain = 0;

    private TextMeshProUGUI textBox;
    //private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox = gameObject.GetComponent<TextMeshProUGUI>(); //Get reference to text
        TextMeshProUGUI highScoreText = GameObject.FindGameObjectWithTag("highScore").GetComponent<TextMeshProUGUI>();
        highScoreText.text = "Most Birds Slain: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //currentTime += Time.deltaTime;
        //textBox.text = Math.Floor(currentTime).ToString();
        textBox.text = birdsSlain + " Birds Slain";
    }

    public void setHighScore(int score) //Call this when game over to set the best time if they beat it
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }

    public void incrementBirdsSlain()
    {
        birdsSlain++;
    }

    public int getBirdsSlain()
    {
        return birdsSlain;
    }
}
