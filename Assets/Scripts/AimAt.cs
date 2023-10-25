using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAt : MonoBehaviour
{
    private Transform target;
    private Transform player;
    private Vector2 aimAt;
    private Vector2 oldAim;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Cursor").GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        oldAim = Vector2.zero;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position != player.position)
        {
            aimAt = target.position - player.position;
            aimAt.Normalize();
            oldAim = aimAt;
            this.transform.right = aimAt;
            this.transform.position = (Vector2)player.position + aimAt * 1.0f;
        }
        else
        {
            this.transform.position = (Vector2)player.position + oldAim * 1.0f;
        }
    }
}
