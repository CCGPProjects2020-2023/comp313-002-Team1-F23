/** Author's Name:          Yusuke Kuroki
 *  Last Modified By:       Yusuke Kuroki
 *  Date Last Modified:     October 29, 2023
 *  Program Description:    This script is used to spawning the player when level is changed or player dies.
 *  Revision History:       October 29, 2023 (Yusuke Kuroki): Initial BuffType script.
 */

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