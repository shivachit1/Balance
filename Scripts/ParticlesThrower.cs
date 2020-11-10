using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesThrower : MonoBehaviour
{
    
    public Transform player;
    public float moveSpeed;
    public string throwObject;
    public float startTime;
    public float repeatTime;
    public GameObject rain;
    public GameObject scoreFlower;
    public GameObject lifeUpFlower;
    public GameObject magnet;
    public GameObject Bomb;
     public GameObject Net;
    public Vector3 newPosition;
    private Transform trans;

    float timer=0;
    float gravity=2.0f;


    void Start()
    {
        trans=transform;

        InvokeRepeating(throwObject,startTime,repeatTime);
    }

    private void FixedUpdate() {
        trans.position = Vector3.Lerp(trans.position,newPosition,Time.deltaTime * moveSpeed);

        if(Mathf.Abs(newPosition.x - trans.position.x) < 0.05){
            trans.position = newPosition;
        }
        
        timer += Time.deltaTime;
        if(timer>10){
            gravity +=1.0f;
            timer=0;

        }
    }


   

       void ThrowRain()
    {
        Rigidbody2D instance = Instantiate(rain.GetComponent<Rigidbody2D>());
        instance.position = trans.position;

        
    }


      void ThrowScoreFlower()
    {
        Rigidbody2D instance = Instantiate(scoreFlower.GetComponent<Rigidbody2D>());
        instance.position = trans.position;
        
    }

      void ThrowLifeUpFlower()
    {
        Rigidbody2D instance = Instantiate(lifeUpFlower.GetComponent<Rigidbody2D>());
         instance.position = trans.position;;
        
        
    }


     void ThrowMagnet()
    {
        Rigidbody2D instance = Instantiate(magnet.GetComponent<Rigidbody2D>());
         instance.position = trans.position;
        
    }

      void ThrowBomb()
    {
        Rigidbody2D instance = Instantiate(Bomb.GetComponent<Rigidbody2D>());
         instance.position = trans.position;
        
    }

       void ThrowNet()
    {
        Rigidbody2D instance = Instantiate(Net.GetComponent<Rigidbody2D>());
         instance.position = trans.position;
        
    }

     private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="rightwall"){
            newPosition = new Vector3(-3.7f,trans.position.y,trans.position.z);
        }
        if(other.tag=="leftwall"){
            newPosition = new Vector3(3.7f,trans.position.y,trans.position.z);
        }
    }
}
