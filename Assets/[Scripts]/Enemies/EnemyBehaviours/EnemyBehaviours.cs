/**Created by Han Bi
 * Used to describe how an enemy behaves
 */

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
    protected virtual void MoveBehaviour() { }

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

}
