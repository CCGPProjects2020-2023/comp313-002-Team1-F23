/* Created by: Han Bi
 * 
 * Last updated by: Han Bi, Oct 12, 2023
 */

using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangedBehaviour : EnemyBehaviours
{
    [SerializeField]
    float attackRadius;

    [SerializeField]
    float attackFrequency;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    Transform projectileSpawnLocation;


    CircleCollider2D attackRange;




    private void Awake()
    {
        //create a circle collider
        CircleCollider2D attackRange = gameObject.AddComponent<CircleCollider2D>();
        attackRange.radius = attackRadius;
        attackRange.isTrigger = true;
    }

    protected override void HandleTargetChange(GameObject newTarget)
    {
        if (newTarget != null)
        {
            currentState = States.Move;
        }
    }

    protected override void IdleBehaviour()
    {
        if(data.GetTarget() != null) 
        {
            currentState = States.Move;
        }
    }



    IEnumerator AttackPlayer()
    {
        while (true)
        {
            var proj = Instantiate(projectilePrefab, projectileSpawnLocation.position, Quaternion.identity);
            //rotate the projectile toward target:
            float angle = VectorCalculation2D.PointTowards(transform.position, data.GetTarget().transform.position, -90f);
            proj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            yield return new WaitForSeconds(attackFrequency);
        }
    }


    //shows the attack range of the object
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentState = States.Attack;
            MoveToAttackTransition();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AttackToMoveTransition();
        }

    }


    private void AttackToMoveTransition()
    {
        StopCoroutine(AttackPlayer());
        currentState = States.Move;
    }

    private void MoveToAttackTransition()
    {
        StartCoroutine(AttackPlayer());
        currentState = States.Attack;
    }
}
