/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Manages experience in the game.
 *  Revision History:       October 26, 2023: Initial ExperienceManager script.
 */

using System;
using UnityEngine;

public class TEMP_ExperienceManager : Singleton<TEMP_ExperienceManager>
{
    public event Action ExperienceThresholdReached;

    [SerializeField] private TEMP_PlayerController player;
    [SerializeField] private LevelUpWindowPresenter levelUpWindowPresenter;

    [SerializeField] private int experiencePoints = 0;

    // States
    public bool IsLevellingUp { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        if (levelUpWindowPresenter != null)
        {
            levelUpWindowPresenter.SkillToLevelUpSelected += OnSkillToLevelUpSelected;
        }
    }
    private void OnDestroy()
    {
        if (levelUpWindowPresenter != null)
        {
            levelUpWindowPresenter.SkillToLevelUpSelected -= OnSkillToLevelUpSelected;
        }
    }
    public void GainExperience(int points)
    {
        experiencePoints += points;
        if (experiencePoints >= 100)
        {
            LevelUp();
            experiencePoints = 0;
        }
    }
    public void LevelUp()
    {
        IsLevellingUp = true;
        ExperienceThresholdReached?.Invoke();        
    }
    private void OnSkillToLevelUpSelected()
    {
        IsLevellingUp = false;
    }
}
