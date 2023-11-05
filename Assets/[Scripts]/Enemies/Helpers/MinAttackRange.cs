/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 2, 2023
 *  Program Description:    Calculates minimum attack range.
 *  Revision History:       November 2, 2023: Initial Script
 */

using UnityEngine;

public class MinAttackRange : MonoBehaviour
{
    [SerializeField]
    RangedBehaviour behaviour;

    private void Start()
    {
        GetComponent<CircleCollider2D>().radius = behaviour.minAttackRange;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            behaviour.ChangeToAttackState();
        }
    }

    private void OnDrawGizmos()
    {
        //min attack range
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, behaviour.minAttackRange);
    }



}
