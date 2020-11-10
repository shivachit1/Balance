using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D magnet;
    GameObject playerGameObject;
    Rigidbody2D player;
    private ParticleSystem _particleSystem;

    void Start()
    {
        magnet= GetComponent<Rigidbody2D>();
        playerGameObject = GameObject.Find("Player");
        player = playerGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(magnet!=null){
           
            if(magnet.position.y<player.position.y-15){
                Destroy(magnet.gameObject);
            }
           
        }
        
    }


    public void AttractParticles(){

        transform.position = Vector2.Lerp(magnet.position,player.position,1.0f * Time.deltaTime);
        
    }
}
