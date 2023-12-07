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

public class CaptureTheHill : Minigame
{
    string playerTag = "Player";
    [SerializeField]
    public float chargeTime;

    private float currentChargeTime = 0f;
    private bool isCharging = false;

    Slider slider;
    ChargingSlider chargingSlider;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isCharging = true;
            chargingSlider.Show(); // Show the slider when entering the charging area
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            isCharging = false;
            currentChargeTime = 0f;
            UpdateSlider(); // Update the slider when the player exits the charging area
            chargingSlider.Hide(); // Hide the slider when exiting the charging area
        }
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        chargingSlider = player.GetComponentInChildren<ChargingSlider>();
        slider = chargingSlider.gameObject.GetComponent<Slider>();
        chargingSlider.Hide();

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
                CompleteMinigame();
                isCharging = false;
                Destroy(gameObject);
            }
        }
    }

    private void UpdateSlider()
    {
        // Calculate the normalized value for the slider
        float normalizedValue = Mathf.Clamp01(currentChargeTime / chargeTime);

        // Update the Slider value
        slider.value = normalizedValue;
    }
}
