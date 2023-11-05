/** Author's Name:          Ikamjot Hundal
 *  Last Modified By:       Ikamjot Hundal
 *  Date Last Modified:     November 4, 2023
 *  Program Description:    A script to test the Heart Buff
 *  Revision History:       November 4, 2023 (Ikamjot Hundal): Initial TestHeart script.
 */

using UnityEngine;

public class TestHeart : MonoBehaviour
{
    //public TEMP_Buff buff;

    public BuffType BuffType;

    [SerializeField] Heart heart;

    [SerializeField] TEMP_HealthManager healthManager;

    [SerializeField] RedTarget redTarget;

    [SerializeField] StopWatch stopWatch;




    // Start is called before the first frame update
    void Start()
    {
       // healthManager = GetComponent<TEMP_HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            heart.ApplyBuff();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            redTarget.ApplyBuff();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            stopWatch.ApplyBuff();
        }
    }
}
