/*
    Author: Yusuke Kuroki
    Date: 2023/10/29
    Description:
        This script is used to spawn the player when level is changed or player dies.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public void SpawnPlayer()
    {
        // need to check if player already exists?
        GameObject player = Instantiate(Resources.Load("Player")) as GameObject;
        player.transform.position = this.transform.position;
    }
}
