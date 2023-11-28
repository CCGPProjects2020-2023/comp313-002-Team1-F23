/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 2, 2023
 *  Program Description:    Calculates the maximum attack range.
 *  Revision History:       November 2, 2023: Initial Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxAttackRange : MonoBehaviour
{
    [SerializeField]
    RangedBehaviour behaviour;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = behaviour.maxAttackRange;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            behaviour.ChangeToMoveState();
        }
    }

    private void OnDrawGizmos()
    {
        //max attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, behaviour.maxAttackRange);

    }

}
