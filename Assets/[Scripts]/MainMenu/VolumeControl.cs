/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     November 1, 2023
 *  Program Description:    Controls volume.
 *  Revision History:       November 1, 2023 (Mithul Koshy): Initial VolumeControl script.
 */

using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;     // Reference to the UI Slider for volume control
    public AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Check if the volumeSlider and audioSource references are set
        if (volumeSlider == null || audioSource == null)
        {
            Debug.LogError("Volume Slider or AudioSource not assigned.");
            enabled = false; // Disable the script
            return;
        }

        // Initialize the volume slider value to the current audio source volume
        volumeSlider.value = audioSource.volume;

        // Add a listener to the slider's value changed event
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float newVolume)
    {
        // Set the audio source volume based on the slider's value
        audioSource.volume = newVolume;
    }
}
