using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public int currentLevel, maxLevel;
    public TMP_Text text;

    public void IncreaseLevel() 
    {
        currentLevel += 1;
        UpdateLevel();
    }

    public void UpdateLevel()
    {
        if (currentLevel > maxLevel)
        {
            currentLevel = maxLevel;
        }
        text.text = currentLevel + "/" + maxLevel;
    }
}
