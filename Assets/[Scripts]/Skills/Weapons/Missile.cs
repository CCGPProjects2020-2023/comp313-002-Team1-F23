/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    A script to handle the Missile.
 *  Revision History:       November 28, 2023 (Mithul Koshy):
 *                          November 29, 2023 (Marcus Ngooi): Adjusted weapon projectile to be consistent with new stats system.
 */

using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float lifespan = 15f;

    private void Awake()
    {
        missileLauncher = GameObject.FindWithTag("MissileLauncher").GetComponent<MissileLauncher>();
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = missileLauncher.CalculatedProjectileSpeed * transform.up;
        Destroy(gameObject, lifespan);
    }

    public void SetEvolvedProperties()
    {
        SpriteRenderer missileSpriteRenderer = GetComponent<SpriteRenderer>();
        if (missileSpriteRenderer != null)
        {
            missileSpriteRenderer.color = Color.blue; // Change to blue for evolved state
        }

    }
}
