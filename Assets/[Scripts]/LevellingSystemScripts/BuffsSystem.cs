using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsSystem : MonoBehaviour
{
    [SerializeField] private bool isLevelledUp = false;

    [SerializeField] private float speedIncrease = 5;
    [SerializeField] private float damageIncrease = 5;


    public Stats.Stat stat;

    public Stats stats;

    // Start is called before the first frame update
    void Start()
    {
        // Call the Level-Up script

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Call the Stats 

    // Check if the levelledUp is true from levelling System. 
    // Two approaches for now.
    // Create a method for each type of type.
    // or just increase numbers for each types of stats in one method.

    // I believes that it will be triggered via the levelled-up menu 
    // So click the button for buff increase--  which then will trigger the method.
    
    // For now.
    public void IncreaseSpeed()
    {
        stat = Stats.Stat.MoveSpeed;

        stats.value += speedIncrease;
    }

    public void IncreaseDamage()
    {
        stat = Stats.Stat.Damage;

        stats.value += damageIncrease;
    }

}
