using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI textBox;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox = gameObject.GetComponent<TextMeshProUGUI>(); //Get reference to text
        TextMeshProUGUI highScoreText = GameObject.FindGameObjectWithTag("highScore").GetComponent<TextMeshProUGUI>();
        highScoreText.text = "Best Time: " + PlayerPrefs.GetString("BestTime", "0");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        textBox.text = Math.Floor(currentTime).ToString();
    }

    void setBestTime(string bestTime) //Call this when game over to set the best time if they beat it
    {
        PlayerPrefs.SetString("BestTime", bestTime);
    }
}
