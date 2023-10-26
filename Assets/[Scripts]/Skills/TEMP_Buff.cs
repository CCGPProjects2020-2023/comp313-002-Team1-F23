using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_Buff : MonoBehaviour
{
    public enum BuffType
    {
        Heart,
        RedTarget,
        Stopwatch
    }
    private string description = "";
    private int currentLevel = 0;
    private int maxLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsMaxLevel()
    {
        return currentLevel >= maxLevel;
    }
}
