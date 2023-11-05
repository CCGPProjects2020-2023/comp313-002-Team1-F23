/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    Handles the behaviour of the laser.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial Laser script.
 */

using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private LaserGun laserGun;
    [SerializeField] private float lifespan = 10f;
    private void Awake()
    {
        laserGun = GameObject.FindWithTag("LaserGun").GetComponent<LaserGun>();
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();

        // baseProjectileSpeed is temp. Must account for base + upgrade
        rBody.velocity = laserGun.WeaponSO.baseProjectileSpeed * transform.up;
        Destroy(gameObject, lifespan);
    }
}
