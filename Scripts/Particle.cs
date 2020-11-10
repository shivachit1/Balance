using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D particle;
    Rigidbody2D player;
    bool magnetActivated=false;


    void Start()
    {
        particle= GetComponent<Rigidbody2D>();
        GameObject playerGameObject = GameObject.Find("Player");
        player = playerGameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(particle!=null){
           
            if(particle.position.y<player.position.y-15){
                Destroy(particle.gameObject);
            }
        
            if(magnetActivated){
               particle.gravityScale = -0.01f;
            particle.position = Vector2.Lerp(particle.position,player.position,5.0f * Time.deltaTime);
                
            }
             
           
        }
        
    }


private void OnTriggerEnter2D(Collider2D other) {
    if(other.tag=="magnetArea"){
        if(particle.gameObject.tag=="flower" || particle.gameObject.tag=="lifeUp"){
            magnetActivated=true;
            Debug.Log(particle.gameObject.tag);
        }
        else{
        magnetActivated=false;
        //Debug.Log(particle.gameObject.tag);
        }
        
    
    }
}
}
