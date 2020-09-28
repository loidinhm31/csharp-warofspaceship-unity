using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{   

    public static GameController instance;
    public int PlayerScore = 0;

    public int BestScore;

    public Text ScoreText;

    public Text BestScoreText;

    public Text StatusText;

    public int DeadTime = 0;

    public GameObject WinPopUp;

    public GameObject BackgroundSound;
    void Start() 
    {
        if (instance == null)
        {
            instance = this;
        } 

        // Get BestScore was saved
        BestScore = PlayerPrefs.GetInt("BestScore");

        // Get Dead Time was saved
        DeadTime = PlayerPrefs.GetInt("DeadTime");
        

        
    }


    // Update is called once per frame
    void Update()
    {   
        CountScore();
    }

   
    public void CountScore()
    {
        ScoreText.text = PlayerScore.ToString();
        
        // Check Current Score vs. Best Score
        if (PlayerScore > BestScore)
        {
            BestScore = PlayerScore;

            PlayerPrefs.SetInt("BestScore", BestScore);
        }

        BestScoreText.text = BestScore.ToString();
    }


    public void ActiveWinPopUp()
    {   
        // Basically, the game is paused
        Time.timeScale = 0;
        
        // Off music
        BackgroundSound.SetActive(false);

        // Show Popup
        WinPopUp.SetActive(true);
        
        
    }


    
    
}
