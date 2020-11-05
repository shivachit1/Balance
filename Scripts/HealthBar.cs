using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  public Slider slider;
  private int health = 5;
  public Gradient gradient;
  public Image filler;


  public bool DecreaseHealth(){

    
      if(health > 1){
          health = health-1;
          slider.value=health;
          filler.color = gradient.Evaluate(slider.normalizedValue);
          return true;
      }else{
          slider.value=0;
          filler.color = gradient.Evaluate(slider.normalizedValue);
          return false;
      }
      

  }

  public void SetMaxHealth(){
      slider.value = 5;
      filler.color = gradient.Evaluate(1f);
  }



}
