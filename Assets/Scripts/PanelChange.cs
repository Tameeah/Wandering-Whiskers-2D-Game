using UnityEngine;

public class PanelChange : MonoBehaviour
{
    public GameObject panelToShow;       // The panel to show on click
    public GameObject panelToHide;       // The panel to hide on click (optional)


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] hits = Physics2D.OverlapPointAll(mousePos);

            foreach (Collider2D hit in hits)
            {
                Debug.Log("Hit: " + hit.gameObject.name);

                // Hide the previous panel if assigned
                if (panelToHide != null)
                    panelToHide.SetActive(false);

                // Show the new panel
                if (panelToShow != null)
                    panelToShow.SetActive(true);
            }
        }
    }
}
