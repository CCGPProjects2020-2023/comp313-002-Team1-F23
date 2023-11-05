/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 1, 2023
 *  Program Description:    Selects the appopriate window in the main menu.
 *  Revision History:       November 1, 2023 (Mithul Koshy): Initial WindowSelection script.
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WindowSelection : MonoBehaviour
{
    public GameObject windowSelectionPanel;
    public Button openWindowSelectionButton;
    public Button backButton;
    public GameObject hideOnWindowSelection; // GameObject to hide when character selection opens

    private void Start()
    {
        // Initially, the character selection panel should be inactive
        windowSelectionPanel.SetActive(false);

        // Add click listeners to the buttons
        openWindowSelectionButton.onClick.AddListener(OpenCharacterSelection);
        backButton.onClick.AddListener(CloseCharacterSelection);
    }

    private void OpenCharacterSelection()
    {
        // Open the character selection panel
        windowSelectionPanel.SetActive(true);

        // Hide the GameObject when character selection opens
        if (hideOnWindowSelection != null)
        {
            hideOnWindowSelection.SetActive(false);
        }
    }

    private void CloseCharacterSelection()
    {
        // Close the character selection panel
        windowSelectionPanel.SetActive(false);

        // Show the GameObject when character selection closes
        if (hideOnWindowSelection != null)
        {
            hideOnWindowSelection.SetActive(true);
        }
    }
}
