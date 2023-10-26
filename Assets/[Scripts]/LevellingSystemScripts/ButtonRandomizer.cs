/* Author's Name: Ikamjot Hundal
 * Created On: October 26, 2023
 * Last Modified By: Ikamjot Hundal
 * Date Last Modified: October 26, 2023 
 * Description: Serves as a way to randomize the buttons
 * Revision History: October 26, 2023: Initial ButtonRandomizer Script, removed the Start 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRandomizer : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;

    public void RandomizeButtons()
    {
        int i = buttonList.Count;
        while (i > 1)
        {
            i--;
            int k = Random.Range(0, i + 1);
            Button temp = buttonList[k];
            buttonList[k] = buttonList[i];
            buttonList[i] = temp;

            Vector3 temPos = buttonList[k].transform.position;
            buttonList[k].transform.position = buttonList[i].transform.position;
            buttonList[i].transform.position = temPos;
        }
    }
}
