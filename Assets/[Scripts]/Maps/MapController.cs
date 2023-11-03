//Created by Mithul Koshy

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
    public GameObject currentChunk;
    PlayerController pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist; // Must be greater than the length and the width of the tilemap
    float OpDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;





    private void Start()
    {
        pm = FindObjectOfType<PlayerController>();

    }

    private void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {

        if (!currentChunk)
        {
            return;
        }

        if(pm.movement.x >0 && pm.movement.y==0) //right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position,checkerRadius,terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }

    

        }

        else if (pm.movement.x < 0 && pm.movement.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }



        }


        else if (pm.movement.x == 0 && pm.movement.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }



        }


        else if (pm.movement.x == 0 && pm.movement.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }



        }

        else if (pm.movement.x > 0 && pm.movement.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightUp").position;
                SpawnChunk();
            }



        }

        else if (pm.movement.x > 0 && pm.movement.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("RightDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("RightDown").position;
                SpawnChunk();
            }



        }

        else if (pm.movement.x < 0 && pm.movement.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftUp").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftUp").position;
                SpawnChunk();
            }



        }


        else if (pm.movement.x < 0 && pm.movement.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("LeftDown").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("LeftDown").position;
                SpawnChunk();
            }



        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk=Instantiate(terrainChunks[rand],noTerrainPosition,Quaternion.identity);
        spawnedChunks.Add(latestChunk);

    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        if(optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;

        }
        else
        {
            return;
        }

        foreach(GameObject chunk in spawnedChunks)
        {
            OpDist=Vector3.Distance(player.transform.position, chunk.transform.position);   
            if(OpDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }

}
