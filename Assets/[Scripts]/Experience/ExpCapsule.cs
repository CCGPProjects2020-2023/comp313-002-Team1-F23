using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCapsule : MonoBehaviour
{
    public float experience;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Add exp to player
            Destroy(gameObject);
        }
    }

}
