/* Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 3rd, 2023 
 * Description:            Manage the CoolDown for the abilities overall
 * ------------------------------------------------------------------------
 * Revision History:       November 3rd, 2023: Initial TEMP_CoolDownManager script.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_CoolDownManager : Singleton<TEMP_CoolDownManager>
{
    public float baseCoolDown = 10f;
    public float coolDownReduction = 0f;
}
