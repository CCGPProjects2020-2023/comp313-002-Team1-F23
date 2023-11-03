/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Base class for a Skill.
 *  Revision History:       October 26, 2023 (Marcus Ngooi): Initial Skill script.
 */

public class Skill
{
    public string Name { get; private set; }
    public int CurrentLevel { get; private set; }
    public int MaxLevel { get; private set; }

    public Skill(string name, int maxLevel)
    {
        this.Name = name;
        this.MaxLevel = maxLevel;
    }

    public void LevelUp()
    {
        CurrentLevel++;
    }
    public bool IsMaxLevel()
    {
        return CurrentLevel >= MaxLevel;
    }
}
