/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 27, 2023
 *  Program Description:    Factory for creating enemy objects 
 *  Revision History:       November 2, 2023: Initial Script
 *                          November 27 (Ikamjot Hundal): Added Elite Version of the enemies. 
 */

using UnityEngine;

public class EnemyFactory : Singleton<EnemyFactory>
{
    [SerializeField]
    GameObject locustPrefab;

    [SerializeField]
    GameObject asteroidGolemPrefab;

    [SerializeField]
    GameObject locustSwarmPrefab;

    [SerializeField]
    GameObject vampireShipPrefab;

    [SerializeField]
    GameObject eliteLocustPrefab;

    [SerializeField]
    GameObject eliteAsteroidGolemPrefab;

    [SerializeField]
    GameObject eliteVampireShipPrefab;

    [SerializeField]
    Transform enemyHolder;

    GameObject player;

    public override void Awake()
    {
        base.Awake();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public GameObject CreateEnemy(Enemy.EnemyType type, Vector2 pos)
    {
        return type switch
        {
            Enemy.EnemyType.Locust => CreateLocust(pos),
            Enemy.EnemyType.VampireShip => CreateVampireShip(pos),
            Enemy.EnemyType.LocustSwarm => CreateLocustSwarm(pos),
            Enemy.EnemyType.AsteroidGolem => CreateAsteroidGolem(pos),
            Enemy.EnemyType.EliteVampireShip => CreateEliteVampireShip(pos),
            Enemy.EnemyType.EliteAsteroidGolem => CreateEliteAsteroidGolem(pos),
            Enemy.EnemyType.EliteLocust => CreateEliteLocust(pos),
            Enemy.EnemyType.Invalid => null,
            _ => null,
        };
    }


    public GameObject CreateLocust(Vector2 pos)
    {
        var _obj = Instantiate(locustPrefab, pos, Quaternion.identity);
        _obj.transform.SetParent(enemyHolder);
        return _obj;
    }

    public GameObject CreateLocustSwarm(Vector2 pos)
    {
        var _obj = Instantiate(locustSwarmPrefab, pos, Quaternion.identity);
        var target = new GameObject();
        Vector2 dest = new(-pos.x, -pos.y);
        target.transform.position = dest;
        _obj.GetComponent<Enemy>().SetTarget(target);
        _obj.transform.SetParent(enemyHolder);

        return _obj;
    }

    public GameObject CreateVampireShip(Vector2 pos)
    {
        var _obj = Instantiate(vampireShipPrefab, pos, Quaternion.identity);
        _obj.transform.SetParent(enemyHolder);
        return _obj;
    }

    public GameObject CreateAsteroidGolem(Vector2 pos)
    {
        var _obj = Instantiate(asteroidGolemPrefab, pos, Quaternion.identity);
        _obj.transform.SetParent(enemyHolder);
        return _obj;
    }

    public GameObject CreateEliteLocust(Vector2 pos)
    {
        var _obj = Instantiate(eliteLocustPrefab, pos, Quaternion.identity);
        _obj.transform.SetParent(enemyHolder);
        return _obj;
    }

    public GameObject CreateEliteVampireShip(Vector2 pos)
    {
        var _obj = Instantiate(eliteVampireShipPrefab, pos, Quaternion.identity);
        _obj.transform.SetParent(enemyHolder);
        return _obj;
    }

    public GameObject CreateEliteAsteroidGolem(Vector2 pos)
    {
        var _obj = Instantiate(eliteAsteroidGolemPrefab, pos, Quaternion.identity);
        _obj.transform.SetParent(enemyHolder);
        return _obj;
    }



    //for testing
    public void CreateLocustSwarmTest()
    {
        CreateLocustSwarm(new Vector3(10, -5));
    }

    //for testing
    public void CreateLocustTest()
    {
        var locust = CreateLocust(new Vector3(5, 8));
        locust.GetComponent<Enemy>().SetTarget(player);
    }

    //for testing
    public void CreateVampireShipTest()
    {
        var ship = CreateVampireShip(new Vector3(-3, 7));
        ship.GetComponent<Enemy>().SetTarget(player);
    }
}
