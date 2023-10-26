/* Author's Name: Ikamjot Hundal
 * Created On: October 11, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 26, 2023 
 * Description: Serves as a System for managing the skills when levelling Up
 * Revision History: October 11, 2023: Initial Buff System Script
 *                   October 25, 2023: Created methods for buttons to be clicked on
 *                   October 26, 2023: Initial ButtonRandomizer Script, removed the Start 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsSystem : MonoBehaviour
{
    [SerializeField] private bool isLevelledUp = false;

    [SerializeField] private float speedIncrease = 5;
    [SerializeField] private float damageIncrease = 5;

    [SerializeField] private ButtonRandomizer buttonRandomizer;

    [SerializeField] private GameObject LevelMenu;



    public Stats.Stat stat;

    public Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        // Call the Level-Up script
        //buttonRandomizer = 
        
    }

    // Update is called once per frame
    void Update()
    {
        // temporary placeholder until the experience manager comes in. 
        OpenLevelMenu();
    }


    // Call the Stats 

    // Check if the levelledUp is true from levelling System. 
    // Two approaches for now.
    // Create a method for each type of type.
    // or just increase numbers for each types of stats in one method.

    // I believes that it will be triggered via the levelled-up menu 
    // So click the button for buff increase--  which then will trigger the method.
    
    // For now.

    public void OpenLevelMenu()
    {
        if (isLevelledUp == true)
        {
            LevelMenu.SetActive(true);
            buttonRandomizer.RandomizeButtons();
            isLevelledUp = false;
        }
    }

    public void IncreaseSpeed()
    {
        //stat = Stats.Stat.MoveSpeed;

        //stats.value += speedIncrease;

        LevelMenu.SetActive(false);
    }

    public void IncreaseDamage()
    {
      //  stat = Stats.Stat.Damage;

      //  stats.value += damageIncrease;

        LevelMenu.SetActive(false);
    }

}
