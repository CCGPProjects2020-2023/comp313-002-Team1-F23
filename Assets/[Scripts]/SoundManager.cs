/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Manages sound --> Plays sounds and changes volume.
 *  Revision History:       October 26, 2023 (Marcus Ngooi): Initial SoundManager script.
 *                          November 28, 2023 (Marcus Ngooi): Add AttackDrone sound effects.
 *                          December 05, 2023 (Mithul Koshy): Add MissileLauncher sound effects.

 */

using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource sfxAudioSource;
    [Header("Additional SFX Audio Sources")]
    [SerializeField] AudioSource levelUpAudioSource;

    [Header("SFX Audio Clips")]
    [SerializeField] AudioClip skillToLevelUpSelectClip;
    [SerializeField] AudioClip collectOreClip;
    [SerializeField] AudioClip levelUpClip;
    [SerializeField] AudioClip shootLaserGunClip;
    [SerializeField] AudioClip DroneShotClip;
    [SerializeField] AudioClip MissileShotClip;

    [Header("Debug")]
    [SerializeField] private float musicVolume = 1f;
    [SerializeField] private float sfxVolume = 1f;
    [SerializeField] private string musicParameter = "MusicVol";
    [SerializeField] private string sfxParameter = "SfxVol";

    private const float setVolumeMultiplier = 20f;

    public float MusicVolume { get { return musicVolume; } }
    public float SfxVolume { get { return sfxVolume; } }

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(musicParameter))
        {
            SetVolume(PlayerPrefs.GetFloat(musicParameter), SoundType.MUSIC);
        }
        else
        {
            PlayerPrefs.SetFloat(musicParameter, 0.5f);
            SetVolume(PlayerPrefs.GetFloat(musicParameter), SoundType.MUSIC);
        }
        if (PlayerPrefs.HasKey(sfxParameter))
        {
            SetVolume(PlayerPrefs.GetFloat(sfxParameter), SoundType.SFX);
        }
        else
        {
            PlayerPrefs.SetFloat(sfxParameter, 0.5f);
            SetVolume(PlayerPrefs.GetFloat(sfxParameter), SoundType.SFX);
        }
    }
    public void ChangeMusic(AudioClip clip)
    {
        if (!musicAudioSource.clip.name.Equals(clip.name)) musicAudioSource.clip = clip;
        musicAudioSource.Play();
    }
    public void PlaySfx(SfxEvent sfxEvent)
    {
        switch (sfxEvent)
        {
            case SfxEvent.SkillToLevelUpSelect:
                sfxAudioSource.PlayOneShot(skillToLevelUpSelectClip);
                break;
            case SfxEvent.CollectOre:
                sfxAudioSource.PlayOneShot(collectOreClip);
                break;
            case SfxEvent.LevelUp:
                StartCoroutine(nameof(PlayLevelUpWithLoweredVolume));
                break;
            case SfxEvent.ShootLaserGun:
                sfxAudioSource.PlayOneShot(shootLaserGunClip);
                break;
            case SfxEvent.DroneShot:
                sfxAudioSource.PlayOneShot(DroneShotClip);
                break;
            case SfxEvent.ShootMissile:
                sfxAudioSource.PlayOneShot(MissileShotClip);
                break;
        }
    }
    public void SetVolume(float value, SoundType type)
    {
        float newValue = Mathf.Log10(value) * setVolumeMultiplier;

        if (value == 0)
        {
            newValue = -100;
        }

        switch (type)
        {
            case SoundType.MUSIC:
                musicVolume = value;
                audioMixer.SetFloat(musicParameter, newValue);
                PlayerPrefs.SetFloat(musicParameter, value);
                break;
            case SoundType.SFX:
                sfxVolume = value;
                audioMixer.SetFloat(sfxParameter, newValue);
                PlayerPrefs.SetFloat(sfxParameter, value);
                break;
            default:
                Debug.LogError("Please assign the sound type before setting volume");
                break;
        }
    }


    private IEnumerator PlayLevelUpWithLoweredVolume()
    {
        Debug.Log("Playing LevelUp Sound");
        // Store the current volume of the sfxAudioSource
        float originalVolume = sfxAudioSource.volume;

        // Lower the volume for all other sound effects
        sfxAudioSource.volume = originalVolume * 0.5f; // Adjust the factor as needed

        // Play the LevelUp sound effect
        levelUpAudioSource.PlayOneShot(levelUpClip, originalVolume);

        // Wait for the LevelUp sound effect to finish playing
        yield return new WaitForSeconds(levelUpClip.length - 1f); //removing one second since clip is 1 second too long

        // Restore the original volume after the LevelUp sound effect is done
        sfxAudioSource.volume = originalVolume;
    }
}
