/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     December 01, 2023
 *  Program Description:    Holds data point for spawning behaviour. Each node represents an period in time.
 *  Revision History:       December 01, 2023 (Han Bi): Initial SpawningNodeSO script.
 */
using System.Collections.Generic;
using UnityEngine;
using static Enemy;

[CreateAssetMenu(fileName = "SpawnNode", menuName = "Scriptable Objects/SpawnNode")]
public class SpawnNodeSO : ScriptableObject
{
    [System.Serializable]
    public class SpecialSpawnObject
    {
        public EnemyType enemyType;
        public int spawnTime;
    }

    [Tooltip("The main enemy prefab that will be spawned")]
    public EnemyType enemyType;

    [Tooltip("This will specify the amount of time that has elapsed in the game before this profile will be effective")]
    public int startTime;

    [Tooltip("Minimum enemies spawned per \'wave\'")]
    public int minSpawnRate;

    [Tooltip("Minimum enemies spawned per \'wave\'")]
    public int maxSpawnRate;

    [Tooltip("This list will specify any special that needs to be spawned")]
    public List<SpecialSpawnObject> specialSpawns;

}
