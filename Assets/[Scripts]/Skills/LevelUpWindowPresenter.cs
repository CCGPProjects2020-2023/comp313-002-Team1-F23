/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Coordinates between the Level Up Window and the other managers.
 *  Revision History:       October 26, 2023: Initial LevelUpWindowPresenter script.
 */

using System.Collections.Generic;
using UnityEngine;

public class LevelUpWindowPresenter : MonoBehaviour
{
    [SerializeField] private Canvas levelUpCanvas;

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
        levelUpCanvas.enabled = true;
    }
    private void HideWindow()
    {
        levelUpCanvas.enabled = false;
    }
    private void PopulateWindow()
    {
        List<object> randomSkills = SkillManager.Instance.GetRandomSkills();

        foreach(Transform child in levelUpCanvas.transform)
        {
            Destroy(child.gameObject);
        }

        foreach(object skill in randomSkills)
        {

        }
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
