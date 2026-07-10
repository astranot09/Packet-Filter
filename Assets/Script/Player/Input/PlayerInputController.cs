using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{

    public static PlayerInputController instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    [Header("Reference")]
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerInteractSystem interactSystem;

    [SerializeField] private PlayerInput playerInput;


    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 dir = ctx.ReadValue<Vector2>();
        playerMovement.SetCurrentDirection(dir);
        if (ctx.performed)
        {
            playerMovement.SetLastDirection(dir);
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            interactSystem.PlayerInteract();
        }
    }

    public void TurnOffPlayerInput()
    {
        if (playerInput != null)
        {
            playerInput.enabled = false;

            // PENTING: Saat input dimatikan, paksa arah gerak player ke 0 
            // agar player tidak "jalan terus" jika input dimatikan saat tombol ditekan
            playerMovement.SetCurrentDirection(Vector2.zero);
        }
    }
    public void TurnOnPlayerInput()
    {
        if (playerInput != null)
        {
            playerInput.enabled = true;
        }
    }
}
