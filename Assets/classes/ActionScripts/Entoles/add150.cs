using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class add150 : ActionScript {

	public override void executeActions(GameManager gm, player pl)
	{
		pl.balance=pl.balance + 150; 

	}

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Player" + pl.playerNo + " get 150 euros");
        this.executeActions(gm, pl);
    }
}
