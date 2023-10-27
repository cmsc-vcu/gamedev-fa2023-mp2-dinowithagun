using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Text healthText;
    public PlayerLogic playerScript;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH : " + playerScript.PlayerHealth;
    }
}
