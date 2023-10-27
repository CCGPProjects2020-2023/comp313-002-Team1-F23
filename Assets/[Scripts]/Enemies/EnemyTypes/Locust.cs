using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locust: Enemy
{
    [SerializeField]
    public float angleOffset;

    void Update()
    {
        LookTowardsTarget();
    }

    private void LookTowardsTarget()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
        }
    }

}
