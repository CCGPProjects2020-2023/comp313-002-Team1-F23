/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Manages the "skills" which are weapons and buffs.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial SkillManager script.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    private List<Weapon> availableWeapons = new();
    private List<TEMP_Buff> availableBuffs = new();

    [SerializeField] private List<Weapon> currentWeapons = new();
    [SerializeField] private List<TEMP_Buff> currentBuffs = new();

    [SerializeField] private int numberOfRandomizedSkills = 3;

    private const string firstWeapon = "LaserGun";

    // Start is called before the first frame update
    void Start()
    {
        availableWeapons = GetComponentsInChildren<Weapon>().ToList();
        availableBuffs = GetComponentsInChildren<TEMP_Buff>().ToList();
        // For now with one character, we manually add this weapon at the beginning
        // as the first character's starting weapon.
        Weapon weaponToAdd = availableWeapons.Find(weapon => weapon.name == firstWeapon);
        currentWeapons.Add(weaponToAdd);
        ActivateWeapon(weaponToAdd);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LevelUpSkill(Skill skill)
    {
        Skill skillToLevelUp;
        if (skill is Weapon)
        {
            skillToLevelUp = currentWeapons.Find(weapon => weapon.name == skill.name);
            if (skillToLevelUp == null)
            {
                Weapon weaponToAdd = availableWeapons.Find(weapon => weapon.name == skill.name);
                AddCurrentWeapon(weaponToAdd);
                ActivateWeapon(weaponToAdd);
            }
        }
        else
        {
            skillToLevelUp = currentBuffs.Find(buff => buff.name == skill.name);
            if (skillToLevelUp == null)
            {
                TEMP_Buff buffToAdd = availableBuffs.Find(buff => buff.name == skill.name);
                AddCurrentBuff(buffToAdd);
                // TODO: ApplyBuff()
            }
        }

        if (skillToLevelUp != null)
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
            index = UnityEngine.Random.Range(0, numberOfRandomizedSkills);
            randomSkills.Add(allSkills[index]);
            allSkills.RemoveAt(index);
        }
        return randomSkills;
    }
    public void AddAvailableWeapon(Weapon weapon)
    {
        availableWeapons.Add(weapon);
    }
    public void AddAvailableBuff(TEMP_Buff buff)
    {
        availableBuffs.Add(buff);
    }
    public void AddCurrentWeapon(Weapon weapon)
    {
        currentWeapons.Add(weapon);
    }
    public void AddCurrentBuff(TEMP_Buff buff)
    {
        currentBuffs.Add(buff);
    }
    public void ActivateWeapon(Weapon weapon)
    {
        weapon.Behaviour();
    }
}
