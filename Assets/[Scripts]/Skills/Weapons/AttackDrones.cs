/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    A script to handle the AttackDrones weapon.
 *  Revision History:       November 3, 2023 (Marcus Ngooi): Initial AttackDrones script.
 *                          November 28, 2023 (Marcus Ngooi): Logic for spawning drones.
 *                                                            Adjustments from WeaponSO change.
 *                          November 29, 2023 (Marcus Ngooi): Adjusted for new stats system.
 */

using UnityEngine;

public class AttackDrones : Weapon
{
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private int numberOfDrones = 2;

    [SerializeField] private bool isActive;

    private GameObject player;
    private Drone droneScript;

    public bool IsActive { get { return isActive; } }

    private void Start()
    {
        isActive = false;

        weaponType = weaponLevelSOs[0].WeaponType;
        skillName = weaponType.ToString();
        maxLevel = weaponLevelSOs[0].MaxLevel;
        CalculateStats();

        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Behaviour()
    {
        isActive = true;

        for (int i = 0; i < numberOfDrones; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfDrones;
            Vector3 position = new(Mathf.Cos(angle), 0, Mathf.Sin(angle));

            GameObject drone = Instantiate(dronePrefab, transform.position + position, Quaternion.identity);
            drone.transform.SetParent(player.transform);
            droneScript = drone.GetComponent<Drone>();
            droneScript.rotationTarget = player;
        }
    }
}
