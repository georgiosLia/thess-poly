using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Afirimeni klassi pou anaparista ena Script pou periexei to kathena ksexwristes energeies ypologismou tou posou plirwmis
//Xrismievei ston ypologismo tou posou plirwmis stous stathmous kai tis ypiresies
public abstract class PropertyPayScript {

    public player Owner;

    public abstract int GetPayAmount(GameObject[] Squares);

    public abstract void SetOwner(player owner);
	
}
