using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelChange : MonoBehaviour
{
    public GameObject panelToShow;
    public GameObject panelToHide;
    public AudioClip clickSound;
    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null )
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject == this.gameObject)
                {
                    Debug.Log("Hit object; " + hit.name);

                    if (panelToHide != null)
                        panelToHide.SetActive(false);

                    if (panelToShow != null)
                        panelToShow.SetActive(true);

                    if (clickSound != null)
                        audioSource.PlayOneShot(clickSound);
                }
  
            }

        }
    }
}
