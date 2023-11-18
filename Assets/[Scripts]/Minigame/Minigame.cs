/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 17, 2023
 *  Program Description:    A manager that manages minigames
 *  Revision History:       November 17, 2023 (Han Bi): Initial script
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base class for minigames.
/// </summary>
public abstract class Minigame : MonoBehaviour
{
    /// <summary>
    /// Holds the weapon type that will be empowered when minigame is successfully completed
    /// </summary>
    public Weapon EmpowerType { get => empowerType; private set => empowerType = value; }

    protected Weapon empowerType;

    //Fires when minigame is successfully completed
    public event Action<Minigame> OnMinigameComplete = delegate { };

    /// <summary>
    /// Initialize must be run whenever minigame is created
    /// </summary>
    public virtual void Initalize(Weapon weaponType)
    {
        empowerType = weaponType;
    }


}
