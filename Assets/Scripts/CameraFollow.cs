using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform cursor;
    public Transform player;
    private Vector2 cameraCenter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraCenter = player.position + ((cursor.position - player.position) * 0.25f);
        transform.position = cameraCenter;
    }
}
