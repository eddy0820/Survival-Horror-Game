using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls controls;
    PlayerControls.PlayerActions playerControls;
    Vector2 horizontalInput;
    Vector2 mouseInput;
    Movement movement;
    FirstPersonCamera firstPersonCamera;
    InteractionManager interactionManager;

    private void Awake()
    {
        controls = new PlayerControls();
        playerControls = controls.Player;
        movement = GetComponent<Movement>();
        firstPersonCamera = GetComponentInChildren<FirstPersonCamera>();
        interactionManager = GetComponent<InteractionManager>();


        playerControls.HorizontalMovement.performed += ctx => 
            horizontalInput = ctx.ReadValue<Vector2>();

        playerControls.MouseX.performed += ctx =>
            mouseInput.x = ctx.ReadValue<float>();
        playerControls.MouseY.performed += ctx =>
            mouseInput.y = ctx.ReadValue<float>();

        playerControls.Interact.performed += _ =>
            interactionManager.OnInteractPressed();
    }

    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        firstPersonCamera.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

}
