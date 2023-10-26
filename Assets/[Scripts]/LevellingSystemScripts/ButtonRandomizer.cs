/* Created by: Ikamjot Hundal (301134374)
 * Triggers when the Levelled Up Menu appears
 * Serves as a way to randomize the buttons
 * Last Updated by: Ikamjot Hundal (Oct 26, 2023)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRandomizer : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList;

    // Start is called before the first frame update
    void Start()
    {
        //RandomizeButtons(buttonList);
        //RandomizeButtons();
        /*for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].transform.SetSiblingIndex(i);
        } */
    }

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
