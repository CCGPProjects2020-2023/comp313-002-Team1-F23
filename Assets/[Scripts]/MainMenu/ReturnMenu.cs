/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Navigates to the main menu when the button is pressed.
 *  Revision History:       November 3, 2023 (Mithul Koshy): Initial MainMenuButton script.
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; 

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(GoToMainMenu);
        }
        else
        {
            Debug.LogWarning("MainMenuButton script attached to an object without a Button component.");
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
