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
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        textBox.text = Math.Floor(currentTime).ToString();
    }
}
