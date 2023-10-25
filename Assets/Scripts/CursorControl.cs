using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    private NTCloneInput _input;
    private Transform cursor;
    Vector2 _position;
    Vector2 setPosition;
    Camera _camera;
    PlayerInput _playerInput;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = this.transform;
        _playerInput = this.GetComponent<PlayerInput>();
        _input = new NTCloneInput();
        cursor = GameObject.Find("Cursor").transform;
        _camera = Camera.main;
        Cursor.visible = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.currentControlScheme == "Keyboard+Mouse") { 
            setPosition = _camera.ScreenToWorldPoint(_position);
            Debug.Log(_position);
        }
        else
        {
            //Mouse.current.WarpCursorPosition(_position);
            setPosition = 4*_position + (Vector2)_player.position;
        }
        cursor.position = setPosition;
        //When we have a replacement texture, use Cursor.SetCursor instead of having a trailing sprite
    }
    void OnControlsChanged()
    {
    }


    void OnMousePosition(InputValue value)
    {
        _position = value.Get<Vector2>();
        Debug.Log(_position);
    }

}
