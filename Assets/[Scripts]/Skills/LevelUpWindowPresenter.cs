/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Coordinates between the Level Up Window and the other managers.
 *  Revision History:       October 26, 2023 (Marcus Ngooi): Initial LevelUpWindowPresenter script.
 *                          December 7, 2023 (Marcus Ngooi): Buttons now appropriately unpopulate.
 */

using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpWindowPresenter : Singleton<LevelUpWindowPresenter>
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
        if (ExperienceManager.Instance != null)
        {
            ExperienceManager.Instance.ExperienceThresholdReached += OnExperienceThresholdReached;
        }
    }

    private void OnDestroy()
    {
        if (ExperienceManager.Instance != null)
        {
            ExperienceManager.Instance.ExperienceThresholdReached -= OnExperienceThresholdReached;
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

        if (randomSkills.Count == 0)
        {
            GameObject buttonGameObj = Instantiate(buttonPrefab);
            buttonGameObj.transform.SetParent(buttonParent, false);
            RectTransform rectTransform = buttonGameObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, 100);
            buttonGameObj.GetComponentInChildren<TextMeshProUGUI>().text = "Continue";
            Button button = buttonGameObj.GetComponent<Button>();
            button.onClick.AddListener(() => OnButtonClickedNoSkills());
        }

        for (int i = 0; i < randomSkills.Count; i++)
        {
            GameObject buttonGameObj = Instantiate(buttonPrefab);
            buttonGameObj.transform.SetParent(buttonParent, false);
            RectTransform rectTransform = buttonGameObj.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0, 100 - 200 * i);
            buttonGameObj.GetComponentInChildren<TextMeshProUGUI>().text = randomSkills[i].name;
            Button button = buttonGameObj.GetComponent<Button>();
            int temp = i;
            button.onClick.AddListener(() => OnButtonClicked(temp));
        }
    }
    private void UnpopulateWindow()
    {
        Button[] buttons = levelUpWindowCanvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i].gameObject);
        }
    }
    private void OnButtonClicked(int index)
    {
        SoundManager.Instance.PlaySfx(SfxEvent.SkillToLevelUpSelect);
        SkillManager.Instance.LevelUpSkill(randomSkills[index]);
        SkillToLevelUpSelected?.Invoke();
        UpdateView();
    }
    private void OnButtonClickedNoSkills()
    {
        SoundManager.Instance.PlaySfx(SfxEvent.SkillToLevelUpSelect);
        SkillToLevelUpSelected?.Invoke();
        UpdateView();
    }
    private void UpdateView()
    {
        if (ExperienceManager.Instance == null) return;

        if (ExperienceManager.Instance.IsLevellingUp)
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
