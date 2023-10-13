/* Created by: Han Bi
 * base class
 * Last updated by: Han Bi, Oct 12, 2023
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    protected enum States
    {
        Idle,
        Move,
        Attack,
    }

    [SerializeField]
    protected GameObject target;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    protected States currentState = States.Idle;

    //implements behaviour when chasing player
    protected virtual void MoveBehaviour() { }

    //implements behaviour when reach/touching player
    protected virtual void AttackBehaviour() { }

    protected virtual void IdleBehaviour() { }

    public void SetTarget(GameObject obj)
    {
        target = obj;
    }

    private void FixedUpdate()
    {
        switch(currentState)
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
        }
    }



}
