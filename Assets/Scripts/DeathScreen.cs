using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public AudioSource music;

    public void OnDeath()
    {
        Time.timeScale = 0;
        music.mute = true;
        gameObject.SetActive(true);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        music.mute = false;
        SceneManager.LoadScene("DinoWithAGun");
    }
}
