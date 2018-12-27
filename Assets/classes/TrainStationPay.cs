using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStationPay : PropertyPayScript
{

    

    

    public override int GetPayAmount(GameObject[] Squares)
    {
        int TrainStationsOwned = 0;
        //5, 15, 25, 35
        if (this.Owner == (Squares[5].GetComponent<square>().sq_card as Property).owner) TrainStationsOwned++;
        if (this.Owner == (Squares[15].GetComponent<square>().sq_card as Property).owner) TrainStationsOwned++;
        if (this.Owner == (Squares[25].GetComponent<square>().sq_card as Property).owner) TrainStationsOwned++;
        if (this.Owner == (Squares[35].GetComponent<square>().sq_card as Property).owner) TrainStationsOwned++;
        switch (TrainStationsOwned)
        {
            case 0:
                return 0;
            case 1:
                return 25;
            case 2:
                return 50;
            case 3:
                return 100;
            case 4:
                return 200;
            
        }
        return 0;
    }

    public override void SetOwner(player owner)
    {
        Owner = owner;
    }
}
