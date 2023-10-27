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
            float angle = VectorCalculation2D.PointTowards(transform.position, target.transform.position, angleOffset);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

}