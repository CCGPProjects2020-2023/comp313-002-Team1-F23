/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Ikamjot Hundal
 *  Date Last Modified:     October 26, 2023
 *  Program Description:    Base class for a Buff.
 *  Revision History:       October 26, 2023: Initial Buff script.
 *                          October 26, 2023: Added features for dealing with child classes
 */


public class TEMP_Buff : Skill
{
    public BuffType Type { get; private set; }

    //public 

    public TEMP_Buff(BuffType type, int maxLevel) : base(type.ToString(), maxLevel)
    {
        this.Type = type;
    }

    public void ApplyBuff()
    {
        if (Type == BuffType.Heart)
        {
            //print()
        }
    }
}
