/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Base class for a Skill.
 *  Revision History:       October 26, 2023 (Marcus Ngooi): Initial Skill script.
 */

using UnityEngine;

public class Skill: MonoBehaviour
{
    [SerializeField] protected string skillName;
    [SerializeField] protected int currentLevel = 0;
    [SerializeField] protected int maxLevel;

    public void LevelUp()
    {
        currentLevel++;
    }
    //public virtual void LevelUp()
    //{
    //    Debug.Log("LevelUp() of base class Skill called.");
    //}
    public bool IsMaxLevel()
    {
        return currentLevel >= maxLevel;
    }
    public bool IsLevelZero()
    {
        return currentLevel == 0;
    }
}
