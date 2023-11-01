using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterSelectionPanel;
    public Button openCharacterSelectionButton;
    public Button backButton;
    public GameObject hideOnCharacterSelection; // GameObject to hide when character selection opens

    private void Start()
    {
        // Initially, the character selection panel should be inactive
        characterSelectionPanel.SetActive(false);

        // Add click listeners to the buttons
        openCharacterSelectionButton.onClick.AddListener(OpenCharacterSelection);
        backButton.onClick.AddListener(CloseCharacterSelection);
    }

    private void OpenCharacterSelection()
    {
        // Open the character selection panel
        characterSelectionPanel.SetActive(true);

        // Hide the GameObject when character selection opens
        if (hideOnCharacterSelection != null)
        {
            hideOnCharacterSelection.SetActive(false);
        }
    }

    private void CloseCharacterSelection()
    {
        // Close the character selection panel
        characterSelectionPanel.SetActive(false);

        // Show the GameObject when character selection closes
        if (hideOnCharacterSelection != null)
        {
            hideOnCharacterSelection.SetActive(true);
        }
    }
}
