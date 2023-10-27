/**Created by Han Bi
 * Used to describe how an enemy behaves
 */

using System.Collections;
using UnityEngine;

public abstract class EnemyBehaviours : MonoBehaviour
{
    protected enum States
    {
        Idle,
        Move,
        Attack,
    }

    [SerializeField]
    protected States currentState = States.Idle;

    protected Enemy data;

    //implements behaviour when chasing player
    protected virtual void MoveBehaviour() 
    { 
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

    //implements behaviour when reach/touching player
    protected virtual void AttackBehaviour() { }

    //a default behaviour, acts as a catch all
    protected virtual void IdleBehaviour() { }

    //observer
    protected abstract void HandleTargetChange(GameObject newTarget);

    protected virtual void Start()
    {
        data = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case States.Idle:
                IdleBehaviour();
                break;
            case States.Move:
                MoveBehaviour();
                break;
            case States.Attack:
                AttackBehaviour();
                break;
            default:
                break;
        }
    }

    protected IEnumerator DealDamage(float damage)
    {
        while (true)
        {
            print($"dealing {damage} damage to player");
            //deal damage to player
            yield return new WaitForSeconds(0.5f);
        }
    }



}
