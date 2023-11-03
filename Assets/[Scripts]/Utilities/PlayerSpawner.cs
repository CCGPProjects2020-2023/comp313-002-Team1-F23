/*
    Author: Yusuke Kuroki
    Date: 2023/10/29
    Description:
        This script is used to spawning the player when level is changed or player dies.
*/
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    public void SpawnPlayer()
    {
        player.gameObject.SetActive(false);
        player.transform.position = this.transform.position;
        player.gameObject.SetActive(true);
    }
}