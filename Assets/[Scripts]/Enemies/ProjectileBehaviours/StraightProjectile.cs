/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     November 2, 2023
 *  Program Description:    Defines behaviour of straight projectiles.
 *  Revision History:       November 2, 2023: Initial Script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour
{
    public float projSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += transform.up * projSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Damage the player
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
