using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apofasi : ActionScript
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
        yield return gm.DisplayMessageForSeconds("You are on Apofasi");
        if (gm.apofasiStack.Count == 0) gm.apofasiStack = new Stack<SpecialCard>(gm.apofasi);
        yield return gm.apofasiStack.Pop().actionScript.OnStay(gm, pl);
    }
}
