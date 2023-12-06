/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 28, 2023
 *  Program Description:    A script to handle the Missile.
 *  Revision History:       November 28, 2023 (Mithul Koshy):
 *                          November 29, 2023 (Marcus Ngooi): Adjusted weapon projectile to be consistent with new stats system.
 *                          December 05, 2023 (Mithul Koshy): Added new missile launcher evolutions

 */

using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float lifespan = 15f;

    private void Start()
    {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();

        if (weapon != null)
        {
            // baseProjectileSpeed is temp. Must account for base + upgrade
            rBody.velocity = weapon.CalculatedProjectileSpeed * transform.up;
        }
        Destroy(gameObject, lifespan);
    }


    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
}
