using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractSystem : MonoBehaviour
{
    [SerializeField] private float interactRadius;
    [SerializeField] private LayerMask interactLayer;

    public void PlayerInteract()
    {
        Debug.Log("Player Interact");
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadius, interactLayer);

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
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
