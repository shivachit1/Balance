using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserData : MonoBehaviour

{
    int score=0;
    string userName;

    public InputField name;
    public Text userNameText;

    // Start is called before the first frame update
    void Start()
    {
        userName = PlayerPrefs.GetString("User Name");
        userNameText.text = "Welcome, "+ userName;
        if(userName !=""){
            name.gameObject.SetActive(false);
            userNameText.gameObject.SetActive(true);
        }else{
            name.gameObject.SetActive(true);
            userNameText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveUserName(){
        userName = name.text;
        
        if(userName!=""){
            PlayerPrefs.SetString("User Name", userName);
        }
        
        
    }

    public void saveHighestScore(int scoreValue){
        if(score < scoreValue){
            score = scoreValue;
            PlayerPrefs.SetString("Highest Score", score.ToString());
        }
        
    }

}
