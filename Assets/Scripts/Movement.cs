using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float playerSpeed = 10f;
    private float horizontalInput;
    private float verticalInput;
    private CharacterController characterController;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }
    void Update()
    {
        ReadInputs();
        movement();
    }
    private void ReadInputs()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void movement()
    {
        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;
        Vector3 movementDirection = forwardMovement + rightMovement;
        characterController.Move(Vector3.ClampMagnitude(movementDirection, 1.0f) * playerSpeed * Time.deltaTime);
    }
}