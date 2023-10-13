/* Created by: Han Bi
 * This enemy moves towards the enemy
 * stops when it is in contact with the target
 * Last updated by: Han Bi, Oct 12, 2023
 */

using UnityEngine;

public class MeleeEnemy : Enemy
{
    private void Start()
    {
        if(target != null)
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
        if (target != null)
        {
            Vector2 newPos = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed);
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

}
