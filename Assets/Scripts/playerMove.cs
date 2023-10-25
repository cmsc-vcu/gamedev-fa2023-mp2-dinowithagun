using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    private Transform player;
    private NTCloneInput _input;
    private Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        player = this.transform;
        _input = new NTCloneInput();
        _input.Gameplay.Enable();
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



 
}
