using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToStart : ActionScript
{
    public override void executeActions(GameManager gm, player pl)
    {
        gm.t_manager.MovePlayerTo(pl, 0);
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Go to start and recieve 200 euros");
        executeActions(gm, pl);
    }
}
