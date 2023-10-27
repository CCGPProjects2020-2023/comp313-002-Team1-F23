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
