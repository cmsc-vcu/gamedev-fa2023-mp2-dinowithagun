using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 12.0f;
    public float angle = 0;
    public Vector3 forward;
    public Vector3 right;
    public Vector3 up;
    // Start is called before the first frame update
    void Start()
    {
        forward = transform.forward;
        right = transform.right;
        up = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((transform.up * speed) * Time.deltaTime, Space.World);
        if(transform.position.magnitude >= 40)
        { 
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
