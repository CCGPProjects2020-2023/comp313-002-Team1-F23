/* Created by: Han Bi
 * specifies an attack range for ranged attacks
 * Last updated by: Han Bi, Oct 12, 2023
 */

using System.Collections;
using UnityEngine;

public class RangedBehaviour : EnemyBehaviours
{

    [SerializeField]
    float attackFrequency;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    Transform projectileSpawnLocation;


    public float minAttackRange;
    public float maxAttackRange;


    private void Awake()
    {
        var collider = gameObject.AddComponent<CircleCollider2D>();
        collider.isTrigger =true;
        collider.radius = maxAttackRange;
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
        if (data.GetTarget() != null)
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



    protected override void MoveBehaviour()
    {
        base.MoveBehaviour();

    }

    public void ChangeToAttackState()
    {
        currentState = States.Attack;
        StartCoroutine(nameof(AttackPlayer));
    }


    public void ChangeToMoveState()
    {
        currentState = States.Move;
        StopCoroutine(nameof(AttackPlayer));
    }


}
