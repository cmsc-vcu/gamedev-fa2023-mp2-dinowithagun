using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public PlayerLogic playerScript;

    public void Revive(){
        SceneManager.LoadScene("DinoWithAGun", LoadSceneMode.Additive);
        playerScript.PlayerHealth = 5;
    }
}
