using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{

    public static UserInput instance;

    public Vector2 MoveInput {  get; private set; }

    private PlayerInput _playerInput;

    private InputAction _moveAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }
    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions["Move"];
    }
    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
    }
}
