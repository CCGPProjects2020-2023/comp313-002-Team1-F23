/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Manages experience in the game.
 *  Revision History:       October 26, 2023: Initial ExperienceManager script.
 */

using System;
using UnityEngine;

public class ExperienceManager : Singleton<ExperienceManager>
{
    public event Action ExperienceThresholdReached;

    [SerializeField] private TEMP_PlayerController player;
    [SerializeField] private LevelUpWindowPresenter levelUpWindowPresenter;

    [SerializeField] private int experiencePoints = 0;
    [SerializeField] private int level;

    [Tooltip("A number > 1. A lower base will make the player level up faster.")]
    [SerializeField] private double natLogBaseValue = 4.0;

    public int Level { get => level; set => level = value; }
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
        int newLevel = CalculateLevel();
        if(newLevel > level)
        {
            level = newLevel;
            LevelUp();
        }
    }
    public void LevelUp()
    {
        IsLevellingUp = true;
        ExperienceThresholdReached?.Invoke();
    }
    private int CalculateLevel()
    {
        // Calculate the level based on the total experience points.
        // The Math.Log function calculates the natural logarithm, so we use it with
        // the base change formula to calculate a logarithm with the specified base.
        int calculatedLevel = (int)(Math.Log(experiencePoints + 1) / Math.Log(natLogBaseValue));

        return calculatedLevel;
    }
    private void OnSkillToLevelUpSelected()
    {
        IsLevellingUp = false;
    }
}
