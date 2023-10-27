using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minDistanceY;
    public float minDistanceX;
    public float spawnRate;
    public GameObject player;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Calculate a random position within the specified range
            Vector3 randomPosition = GenerateRandomSpawnPosition();

            // Instantiate the enemy at the calculated position
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                var enemy = EnemyFactory.Instance.CreateLocust(randomPosition);
                enemy.GetComponent<Enemy>().SetTarget(player);
            }else if (random == 1)
            {
                var enemy = EnemyFactory.Instance.CreateVampireShip(randomPosition);
                enemy.GetComponent<Enemy>().SetTarget(player);
            }else if (random == 2)
            {
                EnemyFactory.Instance.CreateLocustSwarm(randomPosition, new Vector3(randomPosition.x*-1, randomPosition.y*-1, 0));
            }
            // Adjust the spawn rate based on your needs
            yield return new WaitForSeconds(spawnRate);
        }
    }

    Vector3 GenerateRandomSpawnPosition()
    {
        float x = Random.Range(-minDistanceX, minDistanceX);
        float y = Random.Range(-minDistanceY, minDistanceY);

        //we either need to clamp X or Y
        //need to divide numbers by 2 since they will be added to player (at the center)
        float random = Random.Range(-1, 1);
        if(random < 0)//clamp X
        {
            if(x < 0)
            {
                x = -minDistanceX/2;
            }
            else
            {
                x = minDistanceX/2;
            }
            
        }
        else//clamp Y
        {
            if(y < 0)
            {
                y = -minDistanceY/2;
            }
            else
            {
                y = minDistanceY/2;
            }
        }

        return new Vector3(player.transform.position.x + x, player.transform.position.y + y, 0);
    }


    //for testing

    //private void OnDrawGizmos()
    //{

    //    Gizmos.color = new Color(1, 0, 0, 0.3f);
    //    Gizmos.DrawCube(player.transform.position, new Vector3(minDistanceX, minDistanceY, 0));

    //}
}
