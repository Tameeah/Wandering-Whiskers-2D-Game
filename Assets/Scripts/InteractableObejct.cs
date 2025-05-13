using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Interactable : MonoBehaviour
{
    [SerializeField]private GameObject interactionIcon; //UI icon to show when in range
    public string nextSceneName; //Set this to the name of the next scene
    public KeyCode interactKey = KeyCode.E; //Key to press to interact

    private bool playerInRange = false;

    void Start()
    {
        if (interactionIcon != null)
        {
            interactionIcon.SetActive(false); //Hide icon at start
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            Debug.Log("E key pressed - loading scene: " + nextSceneName);
            SceneManager.LoadScene(nextSceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered trigger with: " + other.name);
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactionIcon != null)
            {
                interactionIcon.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactionIcon != null)
            {
                interactionIcon.SetActive(false);
            }
        }
    }
}
