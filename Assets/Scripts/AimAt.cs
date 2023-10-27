using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAt : MonoBehaviour
{
    public Transform target;
    public Transform player;
    private Vector2 aimAt;
    private Vector2 oldAim;
    private SpriteRenderer gunRenderer;
    // Start is called before the first frame update
    void Start()
    {
        oldAim = Vector2.zero;
        gunRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target.position != player.position)
        {
            aimAt = target.position - player.position;
            aimAt.Normalize();
            oldAim = aimAt;
            transform.right = aimAt;
            transform.position = (Vector2)player.position + aimAt * 1.0f;
            if ((transform.position - player.position).x < 0)
            {
                gunRenderer.flipY = true;
            }
            else gunRenderer.flipY = false;
        }
        else
        {
            transform.position = (Vector2)player.position + oldAim * 1.0f;
        }
    }
}
