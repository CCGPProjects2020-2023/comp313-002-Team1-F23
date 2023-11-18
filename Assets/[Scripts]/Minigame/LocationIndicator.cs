/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 17, 2023
 *  Program Description:    Component which creates a arrow indicator on HUD showing gameobject position
 *  Revision History:       November 17, 2023 (Han Bi): Initial script
 */

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Creates a indictor pointing to its location on the HUD
/// </summary>
public class LocationIndicator : MonoBehaviour
{

    [SerializeField]
    GameObject indicatorPrefab;

    [SerializeField]
    LayerMask layerMask;

    Renderer rd;
    GameObject indicator;
    GameObject player;

    private void Start()
    {
        rd = GetComponent<Renderer>();

        if(indicator == null)
        {
            var obj = Instantiate(indicatorPrefab, transform.position, Quaternion.identity);
            obj.transform.SetParent(transform);
            indicator = obj;
        }

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void Update()
    {
        print(rd.isVisible);
        if (!rd.isVisible)
        {
            if (!indicator.activeSelf)
            {
                indicator.SetActive(true);
            }

            Vector2 direction = player.transform.position - transform.position;

            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);

            if(ray.collider != null)
            {
                indicator.transform.position = ray.point;
                indicator.transform.localEulerAngles = new Vector3(0, 0, VectorCalculation2D.PointTowards(player.transform.position, transform.position));
            }
            
        }
        else
        {
            indicator.SetActive(false);
        }
    }


}
