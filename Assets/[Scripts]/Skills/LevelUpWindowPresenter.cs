/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Coordinates between the Level Up Window and the other managers.
 *  Revision History:       October 26, 2023: Initial LevelUpWindowPresenter script.
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindowPresenter : MonoBehaviour
{
    public event Action SkillToLevelUpSelected;

    [SerializeField] private Canvas levelUpWindowCanvas;

    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private RectTransform buttonParent;

    private const int maxNumOfSkills = 3;

    private List<Skill> randomSkills = new();

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
        randomSkills = SkillManager.Instance.GetRandomSkills();

        if (randomSkills.Count > maxNumOfSkills) Debug.LogError("Too many skills!");

        for (int i = 0; i < randomSkills.Count; i++)
        {
            GameObject buttonGameObj = Instantiate(buttonPrefab);
            buttonGameObj.transform.SetParent(buttonParent, false);
            RectTransform rectTransform = buttonGameObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, 100 - 200 * i);
            buttonGameObj.GetComponentInChildren<Text>().text = randomSkills[i].Name;
            Button button = buttonGameObj.GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClicked(i));
        }
    }
    private void UnpopulateWindow()
    {
        Button[] buttons = levelUpWindowCanvas.GetComponentsInChildren<Button>();
        for (int i = 0;i < buttons.Length; i++)
        {
            Destroy(buttons[i]);
        }
    }
    private void OnButtonClicked(int index)
    {
        SkillManager.Instance.LevelUpSkill(randomSkills[index]);
        SkillToLevelUpSelected?.Invoke();
        UpdateView();
    }
    private void UpdateView()
    {
        if (TEMP_ExperienceManager.Instance == null) return;

        if (TEMP_ExperienceManager.Instance.IsLevellingUp)
        {
            ShowWindow();
            PopulateWindow();
        }
        else
        {
            UnpopulateWindow();
            HideWindow();
        }
    }
    private void OnExperienceThresholdReached()
    {
        UpdateView();
    }
}
