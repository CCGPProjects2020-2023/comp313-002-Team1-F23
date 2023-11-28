/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 2, 2023
 *  Program Description:    Manages the behaviour of the Locust Swarm.
 *  Revision History:       November 2, 2023: Initial Script
 */

using System.Collections.Generic;
using UnityEngine;

public class LocustSwarm : Enemy
{
    [SerializeField]
    public int numEnemies;   // Number of enemies to spawn
    [SerializeField]
    public float radius;    // Radius of the circle

    private List<Vector2> enemyPositions = new List<Vector2>();

    private void Start()
    {
        GenerateEnemyPositions();
        SpawnEnemies();
    }

    private void GenerateEnemyPositions()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            // Generate random polar coordinates within the circle
            float randomRadius = Random.Range(0f, radius);
            float randomAngle = Random.Range(0f, 360f);  // Degrees

            // Convert the angle to radians
            float angleInRadians = randomAngle * Mathf.Deg2Rad;

            // Calculate the enemy's position
            float x = transform.position.x + randomRadius * Mathf.Cos(angleInRadians);
            float y = transform.position.y + randomRadius * Mathf.Sin(angleInRadians);

            enemyPositions.Add(new Vector2(x, y));
        }
    }

    private void SpawnEnemies()
    {
        foreach (Vector2 position in enemyPositions)
        {
            var locust = EnemyFactory.Instance.CreateLocust(position);
            locust.transform.SetParent(transform);
            locust.GetComponent<Locust>().SetTarget(target);
        }
    }

    public override void SetTarget(GameObject obj)
    {
        base.SetTarget(obj);
        UpdateChildTarget(obj);
    }


    private void UpdateChildTarget(GameObject target)
    {
        Locust[] childSwarm = GetComponentsInChildren<Locust>();

        foreach(Locust locust in childSwarm)
        {
            locust.SetTarget(target);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
