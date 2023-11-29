/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Manages the "skills" which are weapons and buffs.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial SkillManager script.
 *                          November 17, 2023 (Han Bi): Added OnNewWeaponAdded event and triggers, updated start function
 *                          November 26, 2023 (Ikamjot Hundal): Added BuffActivated and Updated LevelUpSkill
 */

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    //events
    /// <summary>
    /// This is fired when a new type of weapon is slected
    /// </summary>
    public event Action<Weapon> OnNewWeaponAdded = delegate { };

    private List<Weapon> availableWeapons = new();
    private List<Buff> availableBuffs = new();

    [SerializeField] private List<Weapon> currentWeapons = new();
    [SerializeField] private List<Buff> currentBuffs = new();

    [SerializeField] private int numberOfRandomizedSkills = 3;

    private const string firstWeapon = "AttackDrones";

    // Start is called before the first frame update
    void Start()
    {
        availableWeapons = GetComponentsInChildren<Weapon>().ToList();
        availableBuffs = GetComponentsInChildren<Buff>().ToList();

        // For now with one character, we manually add this weapon at the beginning
        // as the first character's starting weapon.
        Weapon weaponToAdd = availableWeapons.Find(weapon => weapon.name == firstWeapon);
        //replaced code with this so event is consistently triggered
        LevelUpSkill(weaponToAdd);
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
                OnNewWeaponAdded(weaponToAdd);
            }
        }
        else
        {
            skillToLevelUp = currentBuffs.Find(buff => buff.name == skill.name);
            if (skillToLevelUp == null)
            {
                Buff buffToAdd = availableBuffs.Find(buff => buff.name == skill.name);
                AddCurrentBuff(buffToAdd);
                ActivateBuff(buffToAdd);
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
    public void AddAvailableBuff(Buff buff)
    {
        availableBuffs.Add(buff);
    }

    public void AddCurrentWeapon(Weapon weapon)
    {
        currentWeapons.Add(weapon);
    }
    public void AddCurrentBuff(Buff buff)
    {
        currentBuffs.Add(buff);
    }
    public void ActivateWeapon(Weapon weapon)
    {
        weapon.Behaviour();
    }

    public void ActivateBuff(Buff buff)
    {
        buff.ApplyBuff();
    }

    public List<Weapon> GetUnEmpoweredWeapons()
    {
        List<Weapon> unempoweredWeapons = new();

        foreach(var weapon in currentWeapons)
        {
            if (!weapon.empowered)
            {
                unempoweredWeapons.Add(weapon);
            }
        }

        return unempoweredWeapons;
    }
}
