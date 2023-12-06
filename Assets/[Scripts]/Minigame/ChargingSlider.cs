using UnityEngine;
using UnityEngine.UI;

public class ChargingSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject visualIndicator;

    private void Update()
    {
        if (playerTransform != null)
        {
            // Orient the slider to face the camera
            transform.parent.rotation = Camera.main.transform.rotation;

            // Set the slider's position above the player with an offset
            transform.position = playerTransform.position + offset;
        }
    }

    public void UpdateChargeSlider(float currentCharge, float maxCharge)
    {
        // Calculate the normalized value for the slider
        float normalizedValue = currentCharge / maxCharge;

        // Update the Slider value
        slider.value = normalizedValue;
    }

    public void Hide()
    {
        if(visualIndicator.activeInHierarchy)
        {
            visualIndicator.SetActive(false);
        }
    }

    public void Show()
    {
        if(!visualIndicator.activeInHierarchy)
        {
            visualIndicator.SetActive(true);
        }
    }


}
