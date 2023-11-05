/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 2, 2023
 *  Program Description:    Manages the behaviour of the Vampire ship. 
 *  Revision History:       November 2, 2023: Initial Script
 */

using UnityEngine;

public class VampireShip : Enemy
{
    [SerializeField]
    float angleOffset;

    private void Update()
    {
        LookTowardsTarget();
    }

    private void LookTowardsTarget()
    {
        if (target != null)
        {
            float angle = VectorCalculation2D.PointTowards(transform.position, target.transform.position, angleOffset);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
