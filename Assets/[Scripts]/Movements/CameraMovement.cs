/** Author's Name:          Laura Amangeldiyeva
 *  Last Modified By:       Laura Amangeldiyeva
 *  Date Last Modified:     October 10, 2023
 *  Program Description:    A script that moves the camera with the Player.
 *  Revision History:       October 10, 2023 (Laura Amangeldiyeva): Initial CameraMove script.
 */

using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
