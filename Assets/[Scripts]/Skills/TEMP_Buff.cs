/* Author's Name:          Marcus Ngooi
 * Last Modified By:       Ikamjot Hundal
 * Date Last Modified:     November 1st, 2023
 * Description:            Base class for a Buff.
 * ------------------------------------------------------------------------
 * Revision History:       October 26, 2023: Initial Buff script.
 *                         October 26, 2023: Added features for dealing with child classes
 *                         October 30, 2023: Converted the method and class to abstract for now and removed the body content. 
 *                         November 1st, 2023: Converted the method to virtual
 */


public abstract class TEMP_Buff : Skill
{
    public BuffType Type { get; private set; }


    //public Heart Heart;
    //public StopWatch StopWatch;
    //public RedTarget RedTarget;

    public TEMP_Buff(BuffType type, int maxLevel) : base(type.ToString(), maxLevel)
    {
        this.Type = type;
    }

    // virtual 

    public virtual void ApplyBuff() { }
    
}
