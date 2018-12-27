using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class goback3 : ActionScript {
	public override void executeActions(GameManager gm, player pl){

        
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("Player" + pl.playerNo + " go 3 steps back");
        


        player currPlayer = pl;
        gm.t_manager.MovePlayer(pl, 37);

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
        else if (currSqCard is SpecialCard)
        {
            MonoBehaviour.print("player " + currPlayer.playerNo + " is on Special square");
            yield return gm.DisplayMessageForSeconds("player " + currPlayer.playerNo + " on Special square");
            //(currSqCard as SpecialCard).callActionScript(this, currPlayer);
            //edw ftiaxnoume tin kathe othoni gia to ti tha emfanizetai kai tetoia
            //edw ektelountai oi energeies analoga se poio tetragwno epese
            //edw mpainei allo cooroutine me yield
        }
    }
}
