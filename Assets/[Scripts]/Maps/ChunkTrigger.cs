/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Triggers the appropriate map chunk.
 *  Revision History:       October 26, 2023 (Mithul Koshy): Initial ChunkTrigger script.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject targetMap;

    void Start()
    {
        mc=FindObjectOfType<MapController>();
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {           
                mc.currentChunk = targetMap;   
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (mc.currentChunk == targetMap)
            {
                mc.currentChunk = null;
            }
        }
    }
}
