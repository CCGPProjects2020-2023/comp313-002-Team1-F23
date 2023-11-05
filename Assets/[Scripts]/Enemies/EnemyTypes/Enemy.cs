/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     October 12, 2023
 *  Program Description:    Base class, contains data about the class
 *  Revision History:       October 12, 2023: Initial Script
 */

using System;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    [SerializeField]
    protected EnemySO data;

    [SerializeField]
    protected GameObject target;

    [SerializeField]
    private GameObject experiencePrefab;

    public float exp;
    public float health;
    public float moveSpeed;
    public float damage;

    public event Action<GameObject> OnTargetChanged  = delegate { };


    private void Awake()
    {
        //fill in the data members to the appropriate locations
        exp = data.baseExp;
        health = data.baseHealth;
        moveSpeed = data.baseSpeed;
        damage = data.baseDamage;
    }

    public virtual void SetTarget(GameObject obj)
    {
        target = obj;
        OnTargetChanged(obj);
    }

    public GameObject GetTarget()
    {
        return target;
    }

    private void DropExp()
    {
        //need to implement some sort of check to see if killed by player
        var capsule = Instantiate(experiencePrefab, transform.position, Quaternion.identity);
        capsule.GetComponent<ExpCapsule>().Experience = exp;
    }



}
