using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax1 : ActionScript
{
    public Tax1()
    {


    }

    public override void executeActions(GameManager gm, player pl)
    {
        pl.Pay(100);
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Income tax you pay 100 euros");
        this.executeActions(gm, pl);
    }
}
