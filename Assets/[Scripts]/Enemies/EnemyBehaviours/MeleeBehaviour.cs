/* Created by: Han Bi
 * This type of enemy moves towards the target
 * stops when it is in contact with the target
 * Last updated by: Han Bi, Oct 12, 2023
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
            StartCoroutine(DealDamage(data.damage));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentState = States.Move;
            StopCoroutine(DealDamage(data.damage));
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
