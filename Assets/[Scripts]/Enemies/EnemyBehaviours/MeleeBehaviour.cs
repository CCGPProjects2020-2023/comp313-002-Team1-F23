/* Created by: Han Bi
 * This enemy moves towards the enemy
 * stops when it is in contact with the target
 * Last updated by: Han Bi, Oct 12, 2023
 */

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

    protected override void MoveBehaviour()
    {
        base.MoveBehaviour();
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (data.GetTarget() != null)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, data.GetTarget().transform.position, data.moveSpeed);
            transform.position = newPos;
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
