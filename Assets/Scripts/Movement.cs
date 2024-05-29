using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Movements")]

    [SerializeField]private float speed = 25;
    [SerializeField]private int rotationSpeed = 150;

    private float rotation;
    private Vector2 moveInput;
    private bool pause;
    private GameObject _canva;

    private void Awake()
    {
        _canva = FindAnyObjectByType<Canvas>().gameObject;
        _canva.SetActive(false);
    }

    void Update()
    {
        //applique les mouvements et les rotation
        ApplyMovement();
        SetPause();
    }

    private void ApplyMovement()
    {
        moveInput.x = UserInput.instance.MoveInput.x;
        moveInput.y = UserInput.instance.MoveInput.y;

        rotation += rotationSpeed * -moveInput.x * Time.deltaTime;

        transform.position += transform.right * moveInput.y * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }

    private void SetPause()
    {
        if (UserInput.instance.pauseInput || UserInput.instance.resumeInput)
        {
            pause = !pause;
            if (pause)
            {
                //Time.timeScale = 0;
                _canva.SetActive(true);
                UserInput.instance._playerInput.SwitchCurrentActionMap("UI");
            }
            else
            {
                //Time.timeScale = 1;
                _canva.SetActive(false);
                UserInput.instance._playerInput.SwitchCurrentActionMap("Player");
            }
        }
    }
}
