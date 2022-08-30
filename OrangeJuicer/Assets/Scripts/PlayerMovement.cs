using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 7;
    public float rotateSpeed = 120;
    public float speed = 7;

    public Vector3 direction;
    public Quaternion moveRotation;
    [Space]
    [Space]

    private Rigidbody rigidbodyComponent;

    private float horizontalInput;
    private float verticalInput;
    //[SerializeField]
    //private Joystick movementJoystick;

    private void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        SetMoveSpeed(speed);
    }
    private void Update()
    {
        MoveCharacter();
        RotateCharacter();
    }

    private void SetMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    private void MoveCharacter()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // + movementJoystick.Horizontal;// Daha keskin bir hareket için GEtAxisRaw tercih edilebilir
        verticalInput = Input.GetAxis("Vertical"); //  + movementJoystick.Vertical; // Daha keskin bir hareket için GEtAxisRaw tercih edilebilir

        direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();

        if (direction.magnitude > 0.1f)
        {
            Manager.manager.StartGame();
        }

        rigidbodyComponent.MovePosition(rigidbodyComponent.position + direction * moveSpeed * Time.deltaTime);
    }

    private void RotateCharacter()
    {
        transform.LookAt(direction + rigidbodyComponent.position);
    }
}
