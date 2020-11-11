using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject HighScoresUI;
    public GameObject GameOverUI;
    public GameObject TimerUI;
    public Text timerText;
    public Text finalScoreText;

    float scoreValue = 0;
    float timer = 3;

   
    // Update is called on fixed rate
   void FixedUpdate()
{
       
                scoreText.text = scoreValue.ToString();

                timer -= Time.deltaTime;
                if(timer > 0){
                        
                        TimerUI.SetActive(true);
                        timerText.text = ""+Mathf.Round(timer);
                }
                else {
                    TimerUI.SetActive(false);
                }
        
       
    }

    public void AddScore(){
            scoreValue +=1;
    }
    public void ShowTimerUI(bool value){
        TimerUI.SetActive(value);
        timer = 5;
    }

    public void HideTimerUI(){
        TimerUI.SetActive(false);
    }

    public void ShowHighScores(){
        HighScoresUI.SetActive(true);
        GameOverUI.SetActive(false);
        GameObject positionGameObject = GameObject.Find("/UI/HighScores/UserPosition/Score");
        Text positionScore = positionGameObject.GetComponent<Text>();
        positionScore.text = scoreText.text;
    }

    public void ShowGameOverUI(){
        HighScoresUI.SetActive(false);
        GameOverUI.SetActive(true);
        finalScoreText.text=scoreText.text;
        PlayerPrefs.SetString("Highest Score", scoreValue.ToString());

    }


}
