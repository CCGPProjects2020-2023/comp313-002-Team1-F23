/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    A class representing a drone that is part of the attack drones weapon.
 *  Revision History:       November 28, 2023 (Marcus Ngooi): Initial Drone script.
 */

using System.Collections;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float laserSpeed = 5f;
    [SerializeField] private GameObject laserPrefab;

    public GameObject rotationTarget;

    private AttackDrones attackDrones;
    private GameObject closestEnemy;

    private void Awake()
    {
        attackDrones = GameObject.Find("AttackDrones").GetComponent<AttackDrones>();
        StartCoroutine(Fire());
    }

    void Update()
    {
        transform.RotateAround(rotationTarget.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);

        transform.rotation = rotationTarget.transform.rotation;
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    //IEnumerator Fire()
    //{
    //    while (attackDrones.IsActive)
    //    {
    //        // Find the closest enemy
    //        closestEnemy = FindClosestEnemy();

    //        SoundManager.Instance.PlaySfx(SfxEvent.DroneShot);

    //        // If an enemy is found, fire a laser at it
    //        if (closestEnemy != null)
    //        {
    //            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
    //            Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
    //            laser.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed;

    //            // Calculate the angle of the direction vector
    //            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

    //            // Set the rotation of the laser
    //            laser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //        }

    //        yield return new WaitForSeconds(attackDrones.CalculatedCooldown);
    //    }
    //}
    IEnumerator Fire()
    {
        while (attackDrones.IsActive)
        {
            // Find the closest enemy
            closestEnemy = FindClosestEnemy();

            // If an enemy is found, fire a laser at it
            if (closestEnemy != null)
            {
                // Determine the number of lasers to fire
                int numLasers = attackDrones.isEvolved ? 3 : 1;

                for (int i = 0; i < numLasers; i++)
                {
                    // Check if the enemy still exists
                    if (closestEnemy == null)
                    {
                        break;
                    }

                    SoundManager.Instance.PlaySfx(SfxEvent.DroneShot);

                    GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
                    Vector3 direction = (closestEnemy.transform.position - transform.position).normalized;
                    laser.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed;

                    // Calculate the angle of the direction vector
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

                    // Set the rotation of the laser
                    laser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                    // If evolved, wait for a short delay before firing the next laser
                    if (attackDrones.isEvolved)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                }
            }

            yield return new WaitForSeconds(attackDrones.CalculatedCooldown);
        }
    }

}
