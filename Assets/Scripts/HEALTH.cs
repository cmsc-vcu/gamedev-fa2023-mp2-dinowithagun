using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HEALTH : MonoBehaviour
{
   public PlayerLogic playerScript;
   public Text healthText;

   void Update(){
    healthText.text = "HEALTH : " + playerScript.PlayerHealth;
   }
}
