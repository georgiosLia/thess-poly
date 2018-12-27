using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pay50 : ActionScript
{
    public override void executeActions(GameManager gm, player pl)
    {
        pl.Pay(50);
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Player " + pl.playerNo + " pays 50 to doctor fee");
        executeActions(gm, pl);
    }
}
