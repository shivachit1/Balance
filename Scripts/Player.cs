using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody2D player;

    // touch position when user touches the screen
    private Vector3 touchPosition;

    // touch direction to move player around, assigned only when screen touch starts.
    private Vector3 direction;

    // For Accelerometer Starting postion
    private Vector2 startingMobilePosition = Vector3.zero;
    // speed for player movement
    private float moveSpeed=10f;

    string gameStatus="start";

    
    public HealthBar healthBar;

    
    public GameObject magnetArea;

    // Game object to call when Particles brusts is needed
    public ParticleBrustManager particleBrustManager;

    // Game running screen score text
    public Text scoreText;

    // UI to show when game is Over, initially assigned as inactive
    public GameObject gameOverUI;
    public Text finalScoreText;

    // score Counter 
    private float scoreValue = 0;


    public GameObject TimerUI;
    public Text timerText;
    bool magnetActivated=false;
    float Timer=3;

    void Start()
    {
        
        player= GetComponent<Rigidbody2D>();
        healthBar.SetMaxHealth();
        startingMobilePosition.x =Input.acceleration.x;
        startingMobilePosition.y =Input.acceleration.y;
        magnetArea.SetActive(false);


        

    }

    // Update is called on fixed rate
   void FixedUpdate()
{
       
         
         if(gameStatus=="start"){
           handleTouchMovement();
           
            scoreText.text = scoreValue.ToString();
         }
         else if (gameStatus=="gameOver"){
            GameOver();
            finalScoreText.text=scoreText.text;
            magnetArea.SetActive(false);

         }


        Timer -= Time.deltaTime;
        magnetArea.transform.position = player.transform.position;
            
        if(Timer > 0){
                TimerUI.SetActive(true);
                timerText.text = ""+Mathf.Round(Timer);
                if(magnetActivated){
                    magnetActivated = false;
                    magnetArea.SetActive(true);
                }
        }else{
               TimerUI.SetActive(false);
              magnetArea.SetActive(false);
        }

        
        
        
           
        
        
       
    }
     
     
    // Acceleration sensor for movement
    private void handleMovement(){
        
        float movementX = Input.acceleration.x;
        float movementY = Input.acceleration.y-startingMobilePosition.y;
            player.velocity = new Vector2(50f*movementX,0);
            
            Debug.Log(movementX);
      
    }

   
   bool playerTouched=false;
    private void handleTouchMovement(){
        

            // touch Functionality (i.e how many places user has touch on screen independently at the moment)
            if(Input.touchCount > 0){

                // only using first touch function ignoring other touches.
                    Touch touch = Input.GetTouch(0);
                  
                        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                         
                         if (touch.phase == TouchPhase.Moved){

                                // Raycast2D layar to check where the user has touched on the screen.
                             RaycastHit2D hitInformation = Physics2D.Raycast(touchPosition, Camera.main.transform.forward);
                            
                            if (hitInformation.collider != null) {
                                
                                // Checking if user has touch on player object 
                                GameObject touchedObject = hitInformation.transform.gameObject;
                                
                                string playerName = touchedObject.transform.name;
                                
                                if(playerName=="Player"){
                                    playerTouched=true;
                                }


                            }

                            // drag movement allowed only when user has first touch the Game object otherwise staying still
                            if(playerTouched){
                                 player.position = new Vector3(touchPosition.x,touchPosition.y+0.5f);
                            }

                         }

                        // touch phase ended, player velocy set to 0, and player touch deactivated. New touch on player object needed to activate again.
                        if(touch.phase == TouchPhase.Ended){
                            player.velocity = Vector2.zero;
                            playerTouched=false;
                        }
                    }
      
    }


void OnTriggerEnter2D(Collider2D other) {
      // if collision to rain drop, then play sound, decrease health, and call to instantiate small water drop particles  
        if(gameStatus!="gameOver"){
            
            if(other.tag=="raindrop"){
                
                bool gameContinue = healthBar.DecreaseHealth();
                particleBrustManager.showRainParticles();
               
                if(!gameContinue){
                    SoundManagerScript.PlayDeadSound();
                     //Destroy (player.gameObject);
                    gameStatus="gameOver";
                    
                   
                }else{
                    SoundManagerScript.PlayWaterDropSound();
                     Destroy(other.gameObject);
                }
             
                    
            }

             // if collision to flower, then play sound, score plus, and call to instantiate small petal particles 
            else if(other.tag=="flower"){
                scoreValue +=1;
                SoundManagerScript.PlayScoreSound();
                particleBrustManager.showFlowerParticles();
                 Destroy(other.gameObject);
            }

              // if collision to flower, then play sound, score plus, and call to instantiate small petal particles 
            else if(other.tag=="lifeUp"){
                healthBar.IncreaseHealth();
                SoundManagerScript.PlayLifeUpSound();
                particleBrustManager.showLifeUpParticles();
                Destroy(other.gameObject);
            }else  if(other.tag=="magnet"){
                Destroy(other.gameObject);
                magnetArea.SetActive(true);
                magnetActivated=true;
                Timer = 5;

            }else if(other.tag=="bomb"){
                SoundManagerScript.PlayExplodeSound();
                particleBrustManager.showBombParticles();
                healthBar.Dead();
                gameStatus = "gameOver";
                 SoundManagerScript.PlayDeadSound();
                Destroy(other.gameObject);
            }
        
        }
    
}

    // particles Collision with Player
    private void OnParticleCollision(GameObject other) {
        
        // if collision to rain drop, then play sound, decrease health, and call to instantiate small water drop particles  
        if(gameStatus!="gameOver"){
            
            if(other.tag=="raindrop"){
                
                bool gameContinue = healthBar.DecreaseHealth();
                particleBrustManager.showRainParticles();

                if(!gameContinue){
                    SoundManagerScript.PlayDeadSound();
                     //Destroy (player.gameObject);
                    gameStatus="gameOver";
                   
                }else{
                    SoundManagerScript.PlayWaterDropSound();
                }
             
                    
            }

             // if collision to flower, then play sound, score plus, and call to instantiate small petal particles 
            else if(other.tag=="flower"){
                scoreValue +=1;
                SoundManagerScript.PlayScoreSound();
                particleBrustManager.showFlowerParticles();
            }

              // if collision to flower, then play sound, score plus, and call to instantiate small petal particles 
            else if(other.tag=="lifeUp"){
                healthBar.IncreaseHealth();
                SoundManagerScript.PlayLifeUpSound();
                particleBrustManager.showLifeUpParticles();
            }
        
        }
        
    }


    // showing Game Over UI
     public  void GameOver(){
            gameOverUI.gameObject.SetActive(true);
    }

    
}
