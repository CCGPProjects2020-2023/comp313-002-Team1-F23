using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeart : MonoBehaviour
{
    public TEMP_Buff buff;

    public BuffType BuffType;

    public Heart heart = new Heart(BuffType.Heart, 1);



    // Start is called before the first frame update
    void Start()
    {
        //BuffType = BuffType.RedTarget;
        //buff.ApplyBuff();
        //Debug.Log($"{buff.Type}");
        heart.ApplyBuff();
        //heart.ApplyBuff();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
