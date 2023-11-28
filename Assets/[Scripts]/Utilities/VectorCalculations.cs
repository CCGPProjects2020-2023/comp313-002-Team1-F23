/** Author's Name:          Han Bi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Used for custom vector calculations that need to be done for project
 *  Revision History:       October 25, 2023 (Han Bi): Initial BuffType script.
 */

using UnityEngine;

public static class VectorCalculation2D 
{ 
    /// <summary>
    /// Returns an angle for the z component in 2D space
    /// </summary>
    /// <param name="currentPos">Current Position</param>
    /// <param name="targetPos">Target Position</param>
    /// <param name="angleOffset">Any offset rotation, default 0</param>
    /// <returns></returns>
    public static float PointTowards(Vector2 currentPos, Vector2 targetPos, float angleOffset = 0)
    {
        Vector2 direction = targetPos - currentPos;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += angleOffset;

        return angle;
    }
}
