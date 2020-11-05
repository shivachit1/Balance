using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        SceneManager.LoadScene(nextSceneName);
        

    }
}
