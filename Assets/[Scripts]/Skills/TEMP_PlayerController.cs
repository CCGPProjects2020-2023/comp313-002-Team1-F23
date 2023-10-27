/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Controls the player.
 *  Revision History:       October 26, 2023: Initial PlayerController script.
 */

using System.Collections.Generic;
using UnityEngine;

public class TEMP_PlayerController : Singleton<TEMP_PlayerController>
{
    public List<TEMP_Weapon> weapons = new();
    public List<TEMP_Buff> buffs = new();
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
        weapons.Add(weapon);
    }
    public void AddBuff(TEMP_Buff buff)
    {
        buffs.Add(buff);
    }
}
