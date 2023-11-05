/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     October 12, 2023
 *  Program Description:    This type of enemy moves towards the target stops when it is in contact with the target
 *  Revision History:       October 12, 2023: Initial Script
 */

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeBehaviour : EnemyBehaviours
{

    protected override void Start()
    {
        base.Start();
        if(data.GetTarget() != null)
        {
            currentState = States.Move;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentState = States.Attack;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentState = States.Move;
        }
    }

    protected override void HandleTargetChange(GameObject newTarget)
    {
        if(newTarget != null)
        {
            currentState = States.Move;
        }
    }
}
