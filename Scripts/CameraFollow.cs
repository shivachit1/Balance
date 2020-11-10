using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public GameObject player;
     public Transform Cam;
 
     void Update () {
         player.transform.Translate(0,0,0.4f);
         Cam.transform.position = new Vector3(Cam.transform.position.x,Cam.transform.position.y,player.transform.position.z - 5);    
     }
}
