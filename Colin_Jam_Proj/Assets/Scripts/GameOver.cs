using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void resetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
