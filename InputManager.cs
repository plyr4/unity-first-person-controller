using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // singleton
    private static InputManager _instance;

    public static InputManager Instance {
        get {
            return _instance;
        }
    }

    // variables
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerLook playerLook;
    private PlayerControls playerControls;

    private void Awake () {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        playerControls = new PlayerControls();

        // playerControls.Player.[action].performed += context => do something
        playerControls.Player.HorizontalMovement.performed += ctx => playerMovement.ReceiveHorizontalInput(ctx.ReadValue<Vector2>());
        playerControls.Player.Jump.performed += _ => playerMovement.ReceiveJump();
        playerControls.Player.Look.performed += ctx =>  playerLook.ReceiveLookInput(ctx.ReadValue<Vector2>());
    }

    private void OnEnable() {
        playerControls.Enable();
    }
    
    private void OnDisable() {
        playerControls.Disable();
    }
}
