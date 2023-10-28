using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    PlayerTest pm;

    private void Start()
    {
        pm = FindObjectOfType<PlayerTest>();

    }

    private void Update()
    {
        ChunkChecker();
    }

    void ChunkChecker()
    {
        if(pm.movement.x >0 && pm.movement.y==0)
        {
            if(!Physics2D.OverlapCircle(player.transform.position + new Vector3(20,0,0),checkerRadius,terrainMask))
            {
                noTerrainPosition = player.transform.position+ new Vector3(20,0,0);
                SpawnChunk();
            }

    

        }

        else if (pm.movement.x < 0 && pm.movement.y == 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 0, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 0, 0);
                SpawnChunk();
            }



        }


        else if (pm.movement.x == 0 && pm.movement.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, 20, 0);
                SpawnChunk();
            }



        }


        else if (pm.movement.x == 0 && pm.movement.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(0, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(0, -20, 0);
                SpawnChunk();
            }



        }

        else if (pm.movement.x > 0 && pm.movement.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, 20, 0);
                SpawnChunk();
            }



        }

        else if (pm.movement.x > 0 && pm.movement.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(20, -20, 0);
                SpawnChunk();
            }



        }

        else if (pm.movement.x < 0 && pm.movement.y > 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, 20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, 20, 0);
                SpawnChunk();
            }



        }


        else if (pm.movement.x < 0 && pm.movement.y < 0)
        {
            if (!Physics2D.OverlapCircle(player.transform.position + new Vector3(-20, -20, 0), checkerRadius, terrainMask))
            {
                noTerrainPosition = player.transform.position + new Vector3(-20, -20, 0);
                SpawnChunk();
            }



        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        Instantiate(terrainChunks[rand],noTerrainPosition,Quaternion.identity);

    }

}
