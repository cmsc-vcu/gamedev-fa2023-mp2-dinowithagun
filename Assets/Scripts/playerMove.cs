using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    private Transform player;
    private NTCloneInput _input;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform;
        _input = new NTCloneInput();
        _input.Gameplay.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = _input.Gameplay.Move.ReadValue<Vector2>();
        player.position += (Vector3)move * 0.1f;
    }
}
