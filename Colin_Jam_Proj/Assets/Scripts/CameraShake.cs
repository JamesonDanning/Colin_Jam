using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Camera mainCam;
    float shakeIntensity = 0;

    private void Awake()
    {
        mainCam = GetComponent<Camera>();
    }

    public void Shake(float amount, float length)
    {
        shakeIntensity = amount;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if (shakeIntensity > 0)
        {
            Vector3 camPos = mainCam.transform.position;
            float offsetX = Random.value * shakeIntensity * 2 - shakeIntensity;
            float offsetY = Random.value * shakeIntensity * 2 - shakeIntensity;
            camPos.x += offsetX;
            camPos.y += offsetY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        mainCam.transform.localPosition = new Vector3(0, 0, -10);
    }
}
