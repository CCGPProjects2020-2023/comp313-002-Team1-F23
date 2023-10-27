using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    GameObject locustPrefab;

    [SerializeField]
    GameObject asteroidPrefab;

    [SerializeField]
    GameObject locustSwarmPrefab;

    public static EnemyFactory Instance { get;  private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
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


    //testing
    public void CreateLocustSwarmTest()
    {
        CreateLocustSwarm(new Vector3(10, -5), new Vector2(-16, 9));
    }

    //testing
    public void CreateLocustTest()
    {
        CreateLocust(new Vector3(5, 8));
    }
}
