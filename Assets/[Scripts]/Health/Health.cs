/** Author's Name:          Sukhmannat Singh
 *  Last Modified By:       Sukhmannat Singh
 *  Date Last Modified:     November 3, 2023
 *  Program Description:    A script that manages health bars.
 *  Revision History:       November 3, 2023 (Sukhmannat Singh): Initial Health script.
 */

using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform unit;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        transform.parent.rotation = Camera.main.transform.rotation;
        transform.position = unit.position + offset;
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth ;
    }
}
