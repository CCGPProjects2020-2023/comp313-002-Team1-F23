/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Manages experience in the game.
 *  Revision History:       October 26, 2023 (Marcus Ngooi): Initial ExperienceManager script.
 *                          November 1, 2023 (Marcus Ngooi): Added sound effect on level up,
 *                                                           Added calculation for current level xp and current required xp.
 *                          November 3, 2023 (Marcus Ngooi): Removed reference to player. The player will refer to this manager.
 */

using System;
using UnityEngine;

public class ExperienceManager : Singleton<ExperienceManager>
{
    public event Action ExperienceThresholdReached;

    [SerializeField] private float experiencePoints = 0;
    [SerializeField] private int level;

    [Tooltip("A number > 1. A lower base will make the player level up faster.")]
    [SerializeField] private double natLogBaseValue = 4.0;

    public int Level { get => level; set => level = value; }
    // States
    public bool IsLevellingUp { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        if (LevelUpWindowPresenter.Instance != null)
        {
            LevelUpWindowPresenter.Instance.SkillToLevelUpSelected += OnSkillToLevelUpSelected;
        }
        else
        {
            Debug.Log("levelUpWindowPresenter was null.");
        }
    }
    private void OnDestroy()
    {
        if (LevelUpWindowPresenter.Instance != null)
        {
            LevelUpWindowPresenter.Instance.SkillToLevelUpSelected -= OnSkillToLevelUpSelected;
        }
    }
    public void GainExperience(float points)
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
        SoundManager.Instance.PlaySfx(SfxEvent.LevelUp);
        IsLevellingUp = true;
        ExperienceThresholdReached?.Invoke();
    }
    private int CalculateLevel()
    {
        // Calculate the level based on the total experience points.
        // The Math.Log function calculates the natural logarithm, so we use it with
        // the base change formula to calculate a logarithm with the specified base.
        // Using a natural logarithm allows us to increase the experience required as the player
        // levels up.
        int calculatedLevel = (int)Math.Round(Math.Log(experiencePoints + 1) / Math.Log(natLogBaseValue));

        return calculatedLevel;
    }
    // This is going to be needed for the HUD
    public float CalculateRequiredExperienceForNextLevel()
    {
        float requiredExperienceForNextLevel = (float)Math.Pow(natLogBaseValue, level + 1) - 1;

        return requiredExperienceForNextLevel;
    }
    // This is going to be needed for the HUD
    public float CalculateCurrentExperienceInCurrentLevel()
    {
        float totalExperienceForCurrentLevel = (float)Math.Pow(natLogBaseValue, level) - 1;
        float currentExperienceInCurrentLevel = experiencePoints - totalExperienceForCurrentLevel;

        return currentExperienceInCurrentLevel;
    }
    private void OnSkillToLevelUpSelected()
    {
        IsLevellingUp = false;
    }
}
