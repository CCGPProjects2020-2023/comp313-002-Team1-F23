/** Author's Name:          Han Bi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     November 1, 2023
 *  Program Description:    Manages experience in the game.
 *  Revision History:       October 25, 2023 (Han Bi): Initial ExpCapsule script. 
 *                          November 1, 2023 (Marcus Ngooi): Call GainExperience from ExperienceManager,
 *                                                           Call PlaySfx from SoundManager,
 *                                                           Made experience private and exposed with property.
 */

using UnityEngine;

public class ExpCapsule : MonoBehaviour
{
    [SerializeField] private float experience;
    public float Experience { get { return experience; } set { experience = value; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ExperienceManager.Instance.GainExperience(experience);
            SoundManager.Instance.PlaySfx(SfxEvent.CollectOre);
            Destroy(gameObject);
        }
    }

}
