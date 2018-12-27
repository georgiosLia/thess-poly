using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//Afirimeni klassi stin opoia asizontai ola ta script energeiwn tou paixnidiou, se auth stirizontai oles oi energeies
public abstract class ActionScript {

    

    public abstract void executeActions(GameManager gm, player pl); //oi energeies pou ektelountai

    public abstract IEnumerator OnPassthrough(GameManager gm, player pl);//Otan o paixtis perasei panw ap to tetragwno ti tha ekteleitai
                                                                         //MI LEITOURGIKO, logo tropou kinisis tou paixti pou prepei na tropopoihthei

    public abstract IEnumerator OnStay(GameManager gm, player pl); //Oi energeies pou ektelountai me to pou pesei sthn analogi karta o paixtis
}
