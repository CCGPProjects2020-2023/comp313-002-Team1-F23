/* Created by: Han Bi
 * 
 * Last updated by: Han Bi, Oct 12, 2023
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : EnemyBehaviours
{
    protected override void HandleTargetChange(GameObject newTarget)
    {
        if(newTarget != null)
        {
            currentState = States.Move;
        }
    }
}
