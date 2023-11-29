/**Author's Name:          Ikamjot Hundal
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 3, 2023 
 * Description:            Manage the CoolDown for the abilities overall
 * ------------------------------------------------------------------------
 * Revision History:       November 3, 2023 (Ikamjot Hundal): Initial TEMP_CoolDownManager script.
 *                         November 28, 2023 (Ikamjot Hundal): removed the default values of the variables. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_CoolDownManager : Singleton<TEMP_CoolDownManager>
{
    public float baseCoolDown;
    public float coolDownReduction;
}
