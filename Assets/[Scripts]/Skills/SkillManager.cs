/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Manages the "skills" which are weapons and buffs.
 *  Revision History:       October 25, 2023: Initial SkillManager script.
 */

using System.Collections.Generic;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    private List<TEMP_Weapon> availableWeapons = new();
    private List<TEMP_Buff> availableBuffs = new();

    [SerializeField] private int numberOfRandomizedSkills = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddWeapon(TEMP_Weapon weapon)
    {
        availableWeapons.Add(weapon);
    }
    public void AddBuff(TEMP_Buff buff)
    {
        availableBuffs.Add(buff);
    }
    public void LevelUpSkill(Skill skill)
    {
        Skill skillToLevelUp;
        if (skill is TEMP_Weapon)
        {
            skillToLevelUp = TEMP_PlayerController.Instance.weapons.Find(weapon => weapon.Name == skill.Name);
        }
        else
        {
            skillToLevelUp = TEMP_PlayerController.Instance.buffs.Find(buff => buff.Name == skill.Name);
        }
        
        if(skillToLevelUp != null)
        {
            skillToLevelUp.LevelUp();
        }
        else
        {
            Debug.Log("Skill not found");
        }
    }
    public List<Skill> GetRandomSkills()
    {
        List<Skill> randomSkills = new();
        List<Skill> allSkills = new();
        allSkills.AddRange(availableWeapons.FindAll(weapon => !weapon.IsMaxLevel()));
        allSkills.AddRange(availableBuffs.FindAll(buff => !buff.IsMaxLevel()));
        int index = 0;

        for (int i = 0; i < numberOfRandomizedSkills; i++)
        {
            index = Random.Range(0, numberOfRandomizedSkills);
            randomSkills.Add(allSkills[index]);
            allSkills.RemoveAt(index);
        }
        return randomSkills;
    }
}
