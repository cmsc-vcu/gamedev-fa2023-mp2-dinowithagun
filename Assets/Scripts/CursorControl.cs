using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    private NTCloneInput _input;
    public GameObject cursor;
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
        _camera = Camera.main;
        Cursor.visible = false;
     
    }

    // Update is called once per frame
    void Update()
    {
        if(_position == Vector2.zero) {
            cursor.GetComponent<Renderer>().enabled = false;
        }
        else {
            cursor.GetComponent<Renderer>().enabled = true;
        }
        if (_playerInput.currentControlScheme == "Keyboard+Mouse") { 
            setPosition = _camera.ScreenToWorldPoint(_position);
        }
        else {
            //float height = Camera.main.orthographicSize * 2;
            //float width = height * Camera.main.aspect;
            //height = (height / 2 - 0.2f);
            //width = (width / 2 - 0.2f);

            setPosition = 12*_position;
            //setPosition.x = Mathf.Clamp(setPosition.x, -width, width);
            //setPosition.y = Mathf.Clamp(setPosition.y, -height, height);
            setPosition += (Vector2)_player.position;
        }
        cursor.transform.position = setPosition;
        //When we have a replacement texture, use Cursor.SetCursor instead of having a trailing sprite
    }

    void OnControlsChanged()
    {
    }


    void OnMousePosition(InputValue value)
    {
        _position = value.Get<Vector2>();
    }

}
