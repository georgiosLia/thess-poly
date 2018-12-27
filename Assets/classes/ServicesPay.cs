using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ServicesPay : PropertyPayScript
{


    public override int GetPayAmount(GameObject[] Squares)
    {
        int ServicesOwned = 0;
        //12, 28
        if (this.Owner == (Squares[12].GetComponent<square>().sq_card as Property).owner) ServicesOwned++;
        if (this.Owner == (Squares[28].GetComponent<square>().sq_card as Property).owner) ServicesOwned++;
        int x = PlayerPrefs.GetInt ("d1");
        int y = PlayerPrefs.GetInt ("d2");
        int DiceSum = x + y;

        switch (ServicesOwned)
        {
            case 0:
                return 0;
            case 1:
                return (DiceSum * 4);
            case 2:
                return (DiceSum * 10);
        }
        return -1;

    }

    public override void SetOwner(player owner)
    {
        this.Owner = owner;
    }

    
}
