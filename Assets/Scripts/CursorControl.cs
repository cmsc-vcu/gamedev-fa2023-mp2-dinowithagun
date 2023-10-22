using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorControl : MonoBehaviour
{
    private NTCloneInput _input;
    private Transform cursor;
    Vector2 _position;
    Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _input = new NTCloneInput();
        _input.Gameplay.MousePosition.Enable();
        cursor = this.transform;
        _camera = Camera.main;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _position = _input.Gameplay.MousePosition.ReadValue<Vector2>();
        Debug.Log(_input.Gameplay.MousePosition.ReadValue<Vector2>());
        _position = _camera.ScreenToWorldPoint(_position);
        cursor.position = _position;
        //Debug.Log(GetComponent<PlayerInput>().currentControlScheme);
        //When we have a replacement texture, use Cursor.SetCursor instead of having a trailing sprite
        //Debug.Log(_position);
        Debug.Log(_input.Gameplay.Fire.IsPressed());
    }
}
