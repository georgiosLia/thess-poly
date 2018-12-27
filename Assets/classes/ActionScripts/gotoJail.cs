using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class gotoJail : ActionScript{

    public override void executeActions(GameManager gm, player pl)
    {
        pl.inJail = true;
        gm.t_manager.MovePlayerTo(pl, TableManager.JAIL);
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("You go tou jail sto kelli 33");
        executeActions(gm, pl);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
