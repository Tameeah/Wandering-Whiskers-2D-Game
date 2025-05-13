using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]


public class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<PolygonCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            collision.GetComponent<PlayerMovement>().OpenInteractableIcon();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.GetComponent <PlayerMovement>().CloseInteractableIcon(); 
    }

}
