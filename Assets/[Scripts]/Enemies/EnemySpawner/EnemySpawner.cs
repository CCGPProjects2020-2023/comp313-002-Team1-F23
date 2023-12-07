/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     Dec. 1, 2023
 *  Program Description:    A spawner used to randomly spawn enemies
 *  Revision History:       November 2, 2023: Initial Script
 *                          November 21, 2023 (Ikamjot Hundal): Bosses Info
 *                          November 27, 2023 (Ikamjot)
 *                          Dec. 1, 2023 Refactored spawn logic
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

public class EnemySpawner : MonoBehaviour
{
    readonly int SPAWN_DELAY = 1;

    [SerializeField]
    private float minDistanceY;
    [SerializeField]
    private float minDistanceX;

    private GameObject player;

    float timeElapsed = 0f;
    float nodeTimeElapsed = 0f;
    int nodeIndex = 0;

    EnemyType mainType;
    
    int nextTransition = -1;
    float enemiesThisWave = 0;
    float incrementPerDelay;

    bool transition = false;

    //for special nodes
    int specialIndex = 0;

    List<SpawnNodeSO.SpecialSpawnObject> specialEnemies;


    //for transitions:
    EnemyType secondaryType;
    [SerializeField]
    [Tooltip("The % of the time the current node needs to elapse before it begins to transition to the next node.")]
    int percentBeginTransition;

    [SerializeField]
    List<SpawnNodeSO> spawnNodes;

    void Start()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
        if(spawnNodes.Count < 1)
        {
            Debug.LogError("Enemy Spawner does not have spawn Nodes");
        }

        nodeIndex = 0;
        CalculateNodeVariables(nodeIndex);
        StartCoroutine(nameof(SpawnWaves));
        StartCoroutine(nameof(CheckForSpecialSpawns));
        
    }

    private void CalculateNodeVariables(int nodeIndex)
    {
        SpawnNodeSO activeNode;
        SpawnNodeSO nextNode;

        try
        {
            activeNode = spawnNodes[nodeIndex];
        }
        catch(Exception e)
        {
            Debug.Log($"Enemy Spawner error:\n{e}");
            return;
        }

        try
        {
            nextNode = spawnNodes[nodeIndex + 1];
        }
        catch
        {
            nextNode = null;
        }

        float waveNumber = 0;
        

        //if there is another node after this, do some additional calculations for transition
        if(nextNode != null)
        {
            transition = true;
            nextTransition = nextNode.startTime;
            secondaryType = nextNode.enemyType;
            waveNumber = (nextNode.startTime - activeNode.startTime)/SPAWN_DELAY;

        }
        else
        {
            transition = false;
            nextTransition = -1;//sets it to be invalid when current node is the last node
            secondaryType = EnemyType.Invalid;
            waveNumber = 60 / SPAWN_DELAY; //by default calculates with 60 seconds
        }

        mainType = activeNode.enemyType;
        incrementPerDelay = (activeNode.maxSpawnRate - activeNode.minSpawnRate) / (float)waveNumber;
        nodeTimeElapsed = 0f;
        enemiesThisWave = activeNode.minSpawnRate;

        specialEnemies = activeNode.specialSpawns;
        specialIndex = 0;
    }


    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if(nextTransition > 0f && timeElapsed >= nextTransition)
        {
            nodeIndex++;
            CalculateNodeVariables(nodeIndex);
        }
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            Debug.Log($"Enemies this wave:{enemiesThisWave}");
            int secondaryEnemiesThisWave = GetNumberOfSecondaryEnemies();

            for (int i = 0; i < enemiesThisWave - secondaryEnemiesThisWave; i++)
            {

                var enemy = EnemyFactory.Instance.CreateEnemy(mainType, GenerateRandomSpawnPosition());
                
                if(enemy != null)
                {
                    enemy.GetComponent<Enemy>().SetTarget(player);
                }
            }

            for (int i = 0; i < secondaryEnemiesThisWave; i++)
            {
                var enemy = EnemyFactory.Instance.CreateEnemy(secondaryType, GenerateRandomSpawnPosition());

                if (enemy != null)
                {
                    enemy.GetComponent<Enemy>().SetTarget(player);
                }
            }

            enemiesThisWave += incrementPerDelay;

            yield return new WaitForSeconds(SPAWN_DELAY);
        }

    }

    IEnumerator CheckForSpecialSpawns()
    {
        while (true)
        {
            if (specialIndex <= specialEnemies.Count - 1) 
            {
                if (timeElapsed >= specialEnemies[specialIndex].spawnTime)
                {
                    EnemyFactory.Instance.CreateEnemy(specialEnemies[specialIndex].enemyType, GenerateRandomSpawnPosition());
                    specialIndex++;
                }
            }
            

            yield return new WaitForSeconds(1f);
        }
    }

    private int GetNumberOfSecondaryEnemies()
    {
        if (transition)
        {
            //calculate probability of spawning a secondary type enemy
            nodeTimeElapsed = timeElapsed - spawnNodes[nodeIndex].startTime;
            float progress = (nodeTimeElapsed / nextTransition) * 100f;
            if (progress > percentBeginTransition)
            {
                float percentTransition = (progress - percentBeginTransition) / (100f - percentBeginTransition);
                int numberOfSecondaryEnemies = (int)((percentTransition / 100) * (enemiesThisWave));
                return numberOfSecondaryEnemies;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }


    Vector3 GenerateRandomSpawnPosition()
    {
        float x = UnityEngine.Random.Range(-minDistanceX, minDistanceX);
        float y = UnityEngine.Random.Range(-minDistanceY, minDistanceY);

        //we either need to clamp X or Y
        //need to divide numbers by 2 since they will be added to player (at the center)
        float random = UnityEngine.Random.Range(-1, 1);
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

        return new Vector3(player.transform.position.x + x, player.transform.position.y + y, 10);
    }


    //for testing

    //private void OnDrawGizmos()
    //{

    //    Gizmos.color = new Color(1, 0, 0, 0.3f);
    //    Gizmos.DrawCube(player.transform.position, new Vector3(minDistanceX, minDistanceY, 0));

    //}
}
