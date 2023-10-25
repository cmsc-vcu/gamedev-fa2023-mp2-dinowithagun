using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private GameObject cursor;
    private GameObject player;
    private Vector2 cameraCenter;

    // Start is called before the first frame update
    void Start()
    {
        cursor = GameObject.Find("Cursor");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraCenter = player.transform.position + ((cursor.transform.position - player.transform.position) * 0.25f);
        this.transform.position = cameraCenter;
    }
}
