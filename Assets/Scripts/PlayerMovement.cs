using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] private InputAction LeftAction;
    [SerializeField] private InputAction MoveAction;

    // private float speed = 30f;

    private void Start()
    {
        MoveAction.Enable();
    }

    void Update()
    {
        Vector2 move = MoveAction.ReadValue<Vector2>();
        //Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * 3.0f * Time.deltaTime;
        transform.position = position;
    }
}
