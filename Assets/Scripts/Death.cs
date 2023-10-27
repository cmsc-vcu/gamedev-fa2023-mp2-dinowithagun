using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
   public PlayerLogic playerScript;

    // Update is called once per frame
    void Update()
    {
        if (playerScript.PlayerHealth <= 0){
            SceneManager.LoadScene("DeathScreen", LoadSceneMode.Additive);
        }
    }
}
