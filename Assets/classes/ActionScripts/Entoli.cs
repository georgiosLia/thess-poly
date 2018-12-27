using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entoli : ActionScript
{
    public override void executeActions(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnPassthrough(GameManager gm, player pl)
    {
        throw new NotImplementedException();
    }

    public override IEnumerator OnStay(GameManager gm, player pl)
    {
        yield return gm.DisplayMessageForSeconds("You are on Entoli");
        if(gm.entoliStack.Count == 0) gm.entoliStack = new Stack<SpecialCard>(gm.entoli);
        yield return gm.entoliStack.Pop().actionScript.OnStay(gm, pl);

    }
}
