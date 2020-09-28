using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{   
    



    public void RestartGame()
    {   
        // Reload Play Scene
        SceneManager.LoadScene("PlayScene");

        // Set time passes as fast as realtime
        Time.timeScale = 1.0f;
    }



}
