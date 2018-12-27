using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//o Typos kartas pou anaparista opoiadipota karta idioktisias h Specia card pou yparxei sot paixnidi
//Kleironomeitai apo tin Property kai thn SpecialCard
public class card {

	//protected player owner;
	public string picture;
	public int id;
    public int sqid;    
    public Sprite icon;
    public square CardSquare;

    public card(string picture,int id,int sqid, Sprite icon)
    {
        ///this.owner = null;
        this.picture = picture;
        this.id = id;
        this.sqid = sqid;
        this.icon = icon;
    }


    //string ToString() { return this.id.ToString}

   
}
