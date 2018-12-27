using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax2 : ActionScript {

    public override void executeActions(GameManager gm, player pl)
    {
        pl.Pay(200);
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("ENFIA kai fetos you pay 200 euros");
        this.executeActions(gm, pl);
    }
}
