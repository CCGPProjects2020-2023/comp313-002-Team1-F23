/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Handles the behaviour of the laser.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial Laser script.
 *                          November 28, 2023 (Marcus Ngooi): Adjusting script to work with all weapon types.
 */

using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    [SerializeField] private float lifespan = 10f;

    private void Start()
    {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();

        if (weapon != null)
        {
            // baseProjectileSpeed is temp. Must account for base + upgrade
            rBody.velocity = weapon.BaseProjectileSpeed * transform.up;
            
        }
        Destroy(gameObject, lifespan);
    }
    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
}
