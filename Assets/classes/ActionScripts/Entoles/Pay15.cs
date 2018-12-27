using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Pay15 : ActionScript {

	public override void executeActions(GameManager gm, player pl)
	{
        pl.Pay(15);

	}

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Player" + pl.playerNo + " pay 15 euros");
        this.executeActions(gm, pl);
    }
}
