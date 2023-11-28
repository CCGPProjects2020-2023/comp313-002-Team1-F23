/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Navigates to the level.
 *  Revision History:       November 3, 2023 (Mithul Koshy): Initial MainMenu script.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
