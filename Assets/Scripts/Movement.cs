using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movements")]

    [SerializeField]private float speed = 25;
    [SerializeField]private int rotationSpeed = 150;

    private float rotation;
    private Vector2 moveInput;

    void Update()
    {
        //applique les mouvements et les rotation
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        moveInput.x = UserInput.instance.MoveInput.x;
        moveInput.y = UserInput.instance.MoveInput.y;

        rotation += rotationSpeed * -moveInput.x * Time.deltaTime;

        transform.position += transform.right * moveInput.y * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }
}
