using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class payplayers50 : ActionScript {

	public override void executeActions(GameManager gm, player pl)
	{
		
		foreach(GameObject p in gm.players) {
            pl.Pay(50, p.GetComponent<player>());   //gia na parei dedomena apo to script player to gameobject  tou kathe paixti kalw prwta thn 
                                                    // (onoma metavlitis paikti).GetComponent<(onoma Component edw vazw player)>().(auto pou xreiazomai)
		}

	}

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Player" + pl.playerNo + " pay 50 euros to every player");
        this.executeActions(gm, pl);
    }
}