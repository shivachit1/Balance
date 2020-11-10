using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip waterDropSound;
    public static AudioClip popSound;
    public static AudioClip lifeUpSound;
    public static AudioClip deadSound;
    public static AudioClip explodeSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        waterDropSound = Resources.Load<AudioClip> ("waterDrop");
        popSound = Resources.Load<AudioClip> ("pop");
        lifeUpSound = Resources.Load<AudioClip> ("powerup");
        deadSound = Resources.Load<AudioClip> ("dead");
        explodeSound= Resources.Load<AudioClip> ("explode");
        audioSrc = GetComponent<AudioSource>();
        
        
    }

    public static void PlayWaterDropSound(){
        audioSrc.PlayOneShot(waterDropSound,1.0f);
    }

      public static void PlayScoreSound(){
        audioSrc.PlayOneShot(popSound,1.0f);
    }
    public static void PlayLifeUpSound(){
        audioSrc.PlayOneShot(lifeUpSound,1.0f);
    }
       public static void PlayDeadSound(){
        audioSrc.PlayOneShot(deadSound,1.0f);
    }

    public static void PlayExplodeSound(){
        audioSrc.PlayOneShot(explodeSound,1.0f);
    }


}
