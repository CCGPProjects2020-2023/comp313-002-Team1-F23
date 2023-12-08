using System.Diagnostics;
/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 17, 2023
 *  Program Description:    Controlls the events and behaviours of the trap minigame
 *  Revision History:       November 17, 2023 (Han Bi): Initial script
 *                          December 07, 2023 (Yusuke Kuroki): Inpmenting the trap minigame
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Minigame
{
	public string playerTag = "Player";
	public EnemyFactory enemyFactory;
	[Range(1, 100)]
	public int maxEmemySpawn = 5;
	[Range(0.0f, 100.0f)]
	public float spawnDistance = 5.0f;
	private int countEnemy;
	private bool isTrapOn = false;

	void Start()
	{
		enemyFactory = GameObject.Find("EnemyFactory").GetComponent<EnemyFactory>();
	}

	void Update()
	{
		if (isTrapOn)
		{
			finishTrap();
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTrapOn && other.CompareTag(playerTag))
        {
			// Spawn enemies randomly
			isTrapOn = true;
			Enemy.EnemyType enemy;
			countEnemy = UnityEngine.Random.Range(1, maxEmemySpawn);
			Vector2 position = new Vector2();

			for (int i = 0; i <= countEnemy; i++)
			{
				enemy = (Enemy.EnemyType)Enum.ToObject(typeof(Enemy.EnemyType), UnityEngine.Random.Range(0, Enum.GetValues(typeof(Enemy.EnemyType)).Length));
				position.x = UnityEngine.Random.Range(this.transform.position.x - spawnDistance, this.transform.position.x + spawnDistance);
				position.y = UnityEngine.Random.Range(this.transform.position.y - spawnDistance, this.transform.position.y + spawnDistance);

				enemyFactory.CreateEnemy(enemy, position);
			}		
        }
    }

	private void finishTrap()
	{
		// Finish minigame
		isTrapOn = false;
		countEnemy = 0;
		CompleteMinigame();
		Destroy(gameObject, 1);
	}
}
