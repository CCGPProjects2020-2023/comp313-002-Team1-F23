using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeart : MonoBehaviour
{
    //public TEMP_Buff buff;

    public BuffType BuffType;

    [SerializeField] Heart heart;

    [SerializeField] TEMP_HealthManager healthManager;

    [SerializeField] RedTarget redTarget;

    [SerializeField] StopWatch stopWatch;




    // Start is called before the first frame update
    void Start()
    {
       // healthManager = GetComponent<TEMP_HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            heart.ApplyBuff();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            redTarget.ApplyBuff();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            stopWatch.ApplyBuff();
        }
    }
}
