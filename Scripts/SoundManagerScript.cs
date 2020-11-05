using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip waterDropSound;
    public static AudioClip popSound;
    public static AudioClip deadSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        waterDropSound = Resources.Load<AudioClip> ("waterDrop");
        popSound = Resources.Load<AudioClip> ("pop");
        deadSound = Resources.Load<AudioClip> ("dead");
        audioSrc = GetComponent<AudioSource>();
        
        
    }

    public static void PlayWaterDropSound(){
        audioSrc.PlayOneShot(waterDropSound,0.8f);
    }

      public static void PlayScoreSound(){
        audioSrc.PlayOneShot(popSound,0.3f);
    }
       public static void PlayDeadSound(){
        audioSrc.PlayOneShot(deadSound,0.1f);
    }


}
