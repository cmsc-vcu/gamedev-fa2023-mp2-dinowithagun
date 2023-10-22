using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAt : MonoBehaviour
{
    private Transform target;
    private Transform player;
    private Vector2 aimAt;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cursor").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        aimAt = target.position - player.position;
        aimAt.Normalize();
        this.transform.right = aimAt;
        this.transform.position = (Vector2)player.position + aimAt * 0.35f;
    }
}
