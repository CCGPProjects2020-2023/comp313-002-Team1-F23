/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023 
 * Description:            Child Class to TEMP_Buff.cs for managing Health
 * ------------------------------------------------------------------------
 * Revision History:       October 26th, 2023: Initial Heart script.
 *                         October 28th, 2023: Updated the script to be the child of TEMP_Buff
 *                         October 30th 2023: Changed to override method
 *                         November 1st, 2023: Setting the BuffType
 *                         November 23rd,2023: Referencing Health Script
 *                         November 24th,2023: Referencing PlayerController Script and resetting the Player Health to max Health 
 */
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public class Heart : Buff
{
    [Header("Do it in point form-- lower-- the higher number is")]
    [SerializeField] private float increaseHealthPercentage = 10f;

    //[SerializeField] TEMP_HealthManager healthManager;

    Health healthController;

    PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        healthController = FindAnyObjectByType<Health>();
    }

    private void Start()
    {
        buffType = BuffType.Heart;
    }

    // health percentage varies based on the level
    // current maxHealth, newMaxHealth,
    // Create new script (Monobehaviour) to say "yo, there are variables being modified," pls remember it  
    // 
    public override void ApplyBuff()
    { 
        PlayerController.Instance.additionalHealth = currentLevel * increaseHealthPercentage / 100 * PlayerController.Instance.maxHealth;

        Debug.Log("Additional Health: " + PlayerController.Instance.additionalHealth);


        PlayerController.Instance.currentHealth = PlayerController.Instance.maxHealth;


        PlayerController.Instance.maxHealth = PlayerController.Instance.maxHealth + PlayerController.Instance.additionalHealth;


        Debug.Log("Player Health: " + PlayerController.Instance.maxHealth);

        healthController.UpdateHealthBar(PlayerController.Instance.currentHealth, PlayerController.Instance.maxHealth); 
    }

    
}
