using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{

    public static UserInput instance;

    public Vector2 MoveInput {  get; private set; }
    public bool pauseInput {  get; private set; }

    public bool returnInput { get; private set; }

    public bool resumeInput { get; private set; }

    public PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _pauseAction;
    private InputAction _returnAction;
    private InputAction _resumeAction;

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
        _pauseAction = _playerInput.actions["Pause"];
        _returnAction = _playerInput.actions["Cancel"];
        _resumeAction = _playerInput.actions["Escape"];
    }
    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        pauseInput = _pauseAction.WasPerformedThisFrame();
        returnInput = _returnAction.WasPerformedThisFrame();
        resumeInput = _resumeAction.WasPerformedThisFrame();
    }
}
