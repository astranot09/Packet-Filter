using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractSystem : MonoBehaviour
{
    [SerializeField] private float interactRadius;
    [SerializeField] private float interactDistance = 1f; // Tambahkan ini agar jarak interaksi bisa diatur
    [SerializeField] private LayerMask interactLayer;

    private Vector2 facingDirection = Vector2.down;

    [SerializeField] private PlayerMovement playerMovement;

    public void PlayerInteract()
    {
        Debug.Log("Player Interact");

        // Ambil arah terakhir
        facingDirection = playerMovement.LastDirection;

        // Kalikan arah dengan interactDistance agar jaraknya bisa kamu atur dari Inspector
        Vector2 finalInteractPosition = (Vector2)transform.position + (facingDirection * interactDistance);

        Collider2D hit = Physics2D.OverlapCircle(finalInteractPosition, interactRadius, interactLayer);

        if (hit != null)
        {
            Debug.Log("Kena");
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract();
            }
            else
            {
                Debug.Log("G jadi");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Biar Gizmos selalu update secara real-time meskipun belum tekan tombol interact
        Vector2 currentDir = facingDirection;
        if (Application.isPlaying && playerMovement != null)
        {
            currentDir = playerMovement.LastDirection;
        }

        Vector2 finalInteractPosition = (Vector2)transform.position + (currentDir * interactDistance);
        Gizmos.DrawWireSphere(finalInteractPosition, interactRadius);
    }
}
