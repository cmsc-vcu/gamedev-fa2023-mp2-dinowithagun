using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    private Transform player;
    public Vector2 move;
    public int PlayerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform;
    }

    private void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        player.position += (Vector3)move * 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            PlayerHealth--;
            if (PlayerHealth <= 0)
            {
                Debug.Log("Player is dead");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth--;
            if (PlayerHealth <= 0)
            {
                Debug.Log("Player is dead");
            }
        }
    }
}
