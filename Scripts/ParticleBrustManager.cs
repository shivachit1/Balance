using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBrustManager : MonoBehaviour
{
    public GameObject flowerParticle;
    public GameObject rainParticle;

    public Transform player;


    // Instantiating flower particles when Player touch flowers.
    public void showFlowerParticles(){
        Instantiate(flowerParticle,player.position,player.rotation);
    }


 // Instantiating water drop particles when Player touch water drop from rain.
     public void showRainParticles(){
        Instantiate(rainParticle,player.position,player.rotation);
    }
}
