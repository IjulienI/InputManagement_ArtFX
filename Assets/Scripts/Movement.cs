using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movements")]

    [SerializeField]private int acceleration = 150;
    [SerializeField]private int maxSpeed = 500;
    [SerializeField]private int rotationAcceleration = 50;
    [SerializeField]private float dragForce;

    private float speed;
    private float rotation;
    void Start()
    {
        
    }

    void Update()
    {
        //applique les mouvements et les rotation
        ApplyMovement();
        ApplyDrag();

        if(Input.GetKey(KeyCode.W))
        {
            AddTransform();
        }
        if (Input.GetKey(KeyCode.S))
        {
            RemoveTransform();
        }
    }


    void AddTransform()
    {
        if(speed < maxSpeed) speed += acceleration * Time.deltaTime;
    }

    void RemoveTransform()
    {
        if(speed > -maxSpeed) speed -= acceleration * Time.deltaTime;
    }

    void AddRotation()
    {
        rotation += rotationAcceleration * Time.deltaTime;
    }

    void RemoveRotation()
    {
        rotation -= rotationAcceleration * Time.deltaTime;
    }

    void ApplyMovement()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
    }

    void ApplyDrag()
    {
        transform.position -= transform.right * (dragForce * (1 * speed)) * Time.deltaTime;
    }
}
