using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] PlayerMovement movement;
    [SerializeField] Flashlight flashlighController;
    [SerializeField] PickupCollectibleController pickupController;
    [SerializeField] PlayerCam mouseLook;
    [SerializeField] PauseMenu pauseMenu;
    PlayerControls controls;
    PlayerControls.GroundMovementActions groundMovement;
    PlayerControls.InteractionActions interactions;
    PlayerControls.UIActions UIActions;
    Vector2 horizontalInput;
    Vector2 mouseInput;

    [Header("Events")]
    public GameEvent onTryPickupCollectible;

    private void Awake()
    {
        controls = new PlayerControls();
        groundMovement = controls.GroundMovement;
        interactions = controls.Interaction;
        UIActions = controls.UI;

        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();


        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.Run.performed += _ => movement.OnRunPressed(true);
        groundMovement.Run.canceled += _ => movement.OnRunPressed(false);
        groundMovement.Crouch.performed += _ => movement.OnCrouchPressed();

        interactions.ControlFlashlight.performed += _ => flashlighController.SetFlashlightState();
        interactions.PickupCollectibles.performed += _ => onTryPickupCollectible.Raise();

        UIActions.Pause.performed += _ => pauseMenu.SetActivePause();
        
    }
    private void Update()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDestroy()
    {
        controls.Disable();
    }
}
