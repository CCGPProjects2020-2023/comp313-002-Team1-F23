/* Created by: Han Bi
 * base class, contains data about the class
 * Last updated by: Han Bi, Oct 12, 2023
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


    private void OnDestroy()
    {
        //need to implement some sort of check to see if killed by player
        var capsule = Instantiate(experiencePrefab, transform.position, Quaternion.identity);
        capsule.GetComponent<ExpCapsule>().experience = exp;
    }



}
