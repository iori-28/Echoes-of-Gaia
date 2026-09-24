using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteract : MonoBehaviour
{
    public Transform interactPoint;
    public float interactRadius = 1.5f;
    public LayerMask interactableplayer;

    void Update()
    {
        if(Keyboard.current == null) return;
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            AttemptInteract();
        }
    }
    void AttemptInteract()
    {
        if(interactPoint == null) return;
        Collider2D[] hits = Physics2D.OverlapCircleAll(interactPoint.position, interactRadius, interactableplayer);

        foreach(Collider2D hit in hits)
        {
            Interactable interactableObj = hit.GetComponent<Interactable>();
            if(interactableObj != null)
            {
                interactableObj.Interact();
                break;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(interactPoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactPoint.position, interactRadius);
    }
}
