/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Coordinates between the Level Up Window and the other managers.
 *  Revision History:       October 26, 2023: Initial LevelUpWindowPresenter script.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindowPresenter : MonoBehaviour
{
    [SerializeField] private Canvas levelUpWindowCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        if (TEMP_ExperienceManager.Instance != null)
        {
            TEMP_ExperienceManager.Instance.ExperienceThresholdReached += OnExperienceThresholdReached;
        }
    }

    private void OnDestroy()
    {
        if (TEMP_ExperienceManager.Instance != null)
        {
            TEMP_ExperienceManager.Instance.ExperienceThresholdReached -= OnExperienceThresholdReached;
        }
    }
    private void ShowWindow()
    {
        levelUpWindowCanvas.enabled = true;
    }
    private void HideWindow()
    {
        levelUpWindowCanvas.enabled = false;
    }
    private void PopulateWindow()
    {
        List<object> randomSkills = SkillManager.Instance.GetRandomSkills();

        Button[] buttons = levelUpWindowCanvas.GetComponentsInChildren<Button>();
        if (buttons.Length < 3)
        {
            Debug.LogError("Not enough buttons in the panel");
        }

        for (int i = 0; i < buttons.Length; i++) { }
       
    }
    private void UpdateView()
    {
        if (TEMP_ExperienceManager.Instance == null) return;

        if (TEMP_ExperienceManager.Instance.IsLevellingUp) ShowWindow();
        else HideWindow();
    }
    private void OnExperienceThresholdReached()
    {
        UpdateView();
    }
}
