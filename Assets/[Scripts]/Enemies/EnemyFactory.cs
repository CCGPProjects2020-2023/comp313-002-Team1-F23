/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 2, 2023
 *  Program Description:    Factory for creating enemy objects 
 *  Revision History:       November 2, 2023: Initial Script
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
    GameObject player;

    public override void Awake()
    {
        base.Awake();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    public GameObject CreateLocust(Vector2 pos)
    {
        var _obj = Instantiate(locustPrefab, pos, Quaternion.identity);
        return _obj;
    }

    public GameObject CreateLocustSwarm(Vector2 pos, Vector2 dest)
    {
        var _obj = Instantiate(locustSwarmPrefab, pos, Quaternion.identity);
        var target = new GameObject();
        target.transform.position = dest;
        _obj.GetComponent<Enemy>().SetTarget(target);

        return _obj;
    }

    public GameObject CreateVampireShip(Vector2 pos)
    {
        var _obj = Instantiate(vampireShipPrefab, pos, Quaternion.identity);

        return _obj;
    }

    public GameObject CreateAsteroidGolem(Vector2 pos)
    {
        var _obj = Instantiate(asteroidGolemPrefab, pos, Quaternion.identity);

        return _obj;
    }


    //for testing
    public void CreateLocustSwarmTest()
    {
        CreateLocustSwarm(new Vector3(10, -5), new Vector2(-16, 9));
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
