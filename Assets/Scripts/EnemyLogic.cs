using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int EnemyHealth = 3;
    public float walkSpeed = 3f;
    public float walkTime = 3f;
    private float walkingTimer;
    public float actionCooldownLength = 3f;
    private float actionCooldown;
    private Vector3 originalPosition;
    public enum EnemyActions {None, Walk}
    public EnemyActions action = EnemyActions.None;
    public Vector2 walkDirection = Vector2.zero;

    public float shotCooldownLength = 0.5f;
    public float shotSpread = 20.0f;
    private float shotCooldown;
    private Vector3 targetDirection;

    private GameObject player;
    public GameObject bulletPrefab;
    private Spawner enemyTypeSpawner;
    public GameObject enemyGun;
    private SpriteRenderer gunRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyTypeSpawner = GameObject.Find("PigSpawner").GetComponent<Spawner>();

        originalPosition = transform.position;
        actionCooldown = actionCooldownLength;
        shotCooldown = shotCooldownLength;
        enemyTypeSpawner.enemyCount++;
        enemyGun = Instantiate(enemyGun);
        enemyGun.transform.position = transform.position + new Vector3(1,0,0);
        gunRenderer = enemyGun.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (action == EnemyActions.Walk)
        {
            if (walkDirection == Vector2.zero)
            {
                Vector3 destination = Vector3.zero;
                while (walkDirection == Vector2.zero || destination.magnitude >= 45)
                {
                    walkDirection = UnityEngine.Random.insideUnitCircle.normalized;
                    destination = (Vector2)transform.position + walkSpeed * walkTime * walkDirection;
                }
                walkingTimer = walkTime;
            }
            transform.Translate(walkDirection * walkSpeed * Time.deltaTime, Space.World);
            walkingTimer -= Time.deltaTime;
            if (walkingTimer <= 0)
            {
                walkDirection = Vector2.zero;
                action = EnemyActions.None;
                actionCooldown = actionCooldownLength;
            }
        }

        else if (actionCooldown <= 0)
        {
            action = EnemyActions.Walk;
        }
        else if (actionCooldown > 0)
        {
            actionCooldown -= Time.deltaTime;
        }

        targetDirection = (player.transform.position - transform.position).normalized;

        if (shotCooldown <= 0) {
            float shotVariance = UnityEngine.Random.Range(-shotSpread + 90, shotSpread + 90);
            Vector3 shotPosition = transform.position + targetDirection;
           
            GameObject bullet = Instantiate(bulletPrefab, shotPosition, (Quaternion.LookRotation(Vector3.forward, targetDirection)) * Quaternion.Euler(0, 0, shotVariance));
            shotCooldown = shotCooldownLength;
        }
        shotCooldown -= Time.deltaTime;

        enemyGun.transform.position = transform.position + targetDirection;
        enemyGun.transform.right = targetDirection;
        if ((enemyGun.transform.position - transform.position).x < 0) gunRenderer.flipY = true;
        else gunRenderer.flipY = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int prevHealth = EnemyHealth;
            EnemyHealth--;
            if (EnemyHealth <= 0) {
                if (prevHealth > 0)
                {
                    enemyTypeSpawner.enemyCount--;
                    Destroy(enemyGun);
                    Destroy(gameObject);
                }
            }
        }
    }
}
