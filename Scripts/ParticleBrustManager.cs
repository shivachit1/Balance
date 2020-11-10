using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBrustManager : MonoBehaviour
{
    public GameObject flowerParticle;
    public GameObject rainParticle;
    public GameObject lifeUpParticle;
    public GameObject bombParticle;

    public Transform player;


    // Instantiating flower particles when Player touch flowers.
    public void showFlowerParticles(){
        Instantiate(flowerParticle,player.position,player.rotation);
    }


 // Instantiating water drop particles when Player touch water drop from rain.
     public void showRainParticles(){
        Instantiate(rainParticle,player.position,player.rotation);
    }


    // Instantiating life up particles when Player touch life up flower.
     public void showLifeUpParticles(){
        Instantiate(lifeUpParticle,player.position,player.rotation);
    }


    // Instantiating life up particles when Player touch life up flower.
     public void showBombParticles(){
        Instantiate(bombParticle,player.position,player.rotation);
        Debug.Log("Shown");
    }
}
