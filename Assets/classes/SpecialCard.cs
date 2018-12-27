using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Anaparista kartes apofasewn, entolwn kai kartes leitourgeinw opws foroi filaki
public class SpecialCard : card {

    public static string ENTOLI = "entoli"; //Stathera pou prosdiorizei ama h karta einai Entoli
    public static string APOFASI = "apofasi";//Stathera pou prosdiorizei ama h karta einai Apofasi

    public string cardType;
    public ActionScript actionScript;   //To script pou periexei tis energeies gia kathe karta ksexwrista

    public SpecialCard(string picture, int id, int sqid, string cardType, ActionScript script, Sprite icon = null) : base(picture, id, sqid, icon)
    {
        this.cardType = cardType;
        actionScript = script;
    }

    public IEnumerator callActionScript(GameManager gm, player pl)  //Mesw auths kalountai oi energeies gia kathe script
    {
        if (this.actionScript == null) MonoBehaviour.print("ActionScript is null");
        else
        {
            yield return actionScript.OnStay(gm, pl);   //Ektelountai mono oi energeies OnStay()
            
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
