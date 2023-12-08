/**Author's Name:          Marcus Ngooi
 * Last Modified By:       Marcus Ngooi
 * Date Last Modified:     November 1st, 2023
 * Description:            Base class for a Buff.
 * ------------------------------------------------------------------------
 * Revision History:       October 26, 2023 (Marcus Ngooi): Initial Buff script.
 *                         October 26, 2023 (Ikamjot Hundal): Added features for dealing with child classes
 *                         October 30, 2023 (Ikamjot Hundal): Converted the method and class to abstract for now and removed the body content. 
 *                         November 1st, 2023 (Ikamjot Hundal): Converted the method to virtual
 *                         November 29, 2023 (Marcus Ngooi): Adjusted Buff to be consistent with new stats system.
 */

using System.Collections.Generic;
using UnityEngine;
public class Buff : Skill
{
    [SerializeField] protected BuffType buffType;
    [SerializeField] protected List<BuffSO> buffLevelSOs = new();

    public BuffType BuffType { get { return buffType; } }

    public virtual void ApplyBuff() { }

    public float GetBuffAmount()
    {
        return buffLevelSOs[currentLevel].BaseBuffAmount;
    }
}
