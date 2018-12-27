using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class gotoblue2 : ActionScript {

	public override void executeActions(GameManager gm, player pl)
	{
		gm.t_manager.MovePlayerTo (pl, 39);
	}
	public override IEnumerator OnPassthrough(GameManager gm, player pl)
	{
		throw new NotImplementedException();
	}

	public override IEnumerator OnStay(GameManager gm, player pl)
	{
        yield return gm.DisplayMessageForSeconds("Player" + pl.playerNo + " go to Lefkos Pirgos");



        player currPlayer = pl;
        gm.t_manager.MovePlayerTo(currPlayer, 39);

        card currSqCard = currPlayer.GetComponent<player>().currentSquare.sq_card;
        if (currSqCard is Property)
        {
            //print("player " + currPlayer.playerNo + " is on Property square");
            yield return gm.DisplayMessageForSeconds("player " + currPlayer.playerNo + " on Property square");
            //edw ektelountai oi energeies sthn idioktisia analoga se poion anikei kai tetoia
            //edw mpainei allo cooroutine me yield
            if (currPlayer.IsProperty(currSqCard))
            {
                yield return gm.DisplayMessageForSeconds("player " + currPlayer.playerNo + " already owns this property");
            }


            //Edw ksekinaei to cooroutine tou parathirou pou kanei tin agora kai tetoia
            yield return gm.OnProperty((Property)currSqCard, currPlayer);

        }
    }
}

