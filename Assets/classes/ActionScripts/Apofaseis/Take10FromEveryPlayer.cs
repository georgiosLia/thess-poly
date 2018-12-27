using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take10FromEveryPlayer : ActionScript
{
    public override void executeActions(GameManager gm, player pl)
    {
        foreach(GameObject p in gm.players)
        {
            p.GetComponent<player>().Pay(10, pl);
        }
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Its your birthday tyxere!!, pare 10 euro apo kathe paixti");
        executeActions(gm, pl);
    }
}
