using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HighScoreController : MonoBehaviour
{
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
