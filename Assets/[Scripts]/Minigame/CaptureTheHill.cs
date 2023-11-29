/** Author's Name:          Han Bi
 *  Modified By:       Han Bi
 *  Date Last Modified:     November 17, 2023
 *  Program Description:    Controlls the events and behaviours of the capture the hill minigame
 *  Revision History:       November 17, 2023 (Han Bi): Initial script
 *  
 *  
 *  Last Modified By: Laura Amangeldiyeva
 *  Date Last Modified: November 27, 2023
 *  Program Description:    Finilized and modified the script to finish the minigame
 *  Revision History:       November 27, 2023 (Laura Amangeldiyeva): Modified script
 */

using UnityEngine;
using UnityEngine.UI;

public class CaptureTheHill : MonoBehaviour
{
    public string playerTag = "Player";
    public float chargeTime = 45f;

    private float currentChargeTime = 0f;
    private bool isCharging = false;

    public Slider chargingSlider; // Reference to the Slider component

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isCharging = true;
            chargingSlider.gameObject.SetActive(true); // Show the slider when entering the charging area
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isCharging = false;
            currentChargeTime = 0f;
            UpdateSlider(); // Update the slider when the player exits the charging area
            chargingSlider.gameObject.SetActive(false); // Hide the slider when exiting the charging area
        }
    }

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        ChargingSlider S = Player.GetComponentInChildren<ChargingSlider>();
        chargingSlider = S.gameObject.GetComponent<Slider>();

    }

    private void Update()
    {
        if (isCharging)
        {
            if (currentChargeTime < chargeTime)
            {
                currentChargeTime += Time.deltaTime;
                UpdateSlider(); // Update the slider during charging
            }
            else
            {
                Debug.Log("Hill captured!");
                SpawnChargingStation();
            }
        }
    }

    private void UpdateSlider()
    {
        // Calculate the normalized value for the slider
        float normalizedValue = currentChargeTime / chargeTime;

        // Update the Slider value
        chargingSlider.value = normalizedValue;
    }

    private void SpawnChargingStation()
    {
        // Implement spawning logic as needed
        // For example, you can instantiate a new charging station prefab here
        Debug.Log("Charging station spawned!");
    }
}
