using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Recieve200 : ActionScript {
    public override void executeActions(GameManager gm, player pl)
    {
        pl.addMoney(200);
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Bank mistake. Player " + " recieve 200 euros ");
        executeActions(gm, pl);
    }

}
