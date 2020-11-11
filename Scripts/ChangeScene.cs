using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    
    public string currentSceneName;
    public string nextSceneName;
 

    // resume the current scene 
    public void resumeScene(){
        SceneManager.LoadScene(currentSceneName);
        SoundManagerScript.PlayWaterDropSound();

    }

    // change the scene with given name
    public void changeScene(){
        string name = PlayerPrefs.GetString("User Name");
        if(name!=""){

            SceneManager.LoadScene(nextSceneName);
        
        }else{
            GameObject blinker = GameObject.Find("/Canvas/InputField/blinker");
            blinker.SetActive(true);
        }

    }
}
