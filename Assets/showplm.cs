using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showplm : MonoBehaviour {

	public Text t1, t2, t3, t4;
	public GameManager m;
	private GameObject[] p;
	private int pn;

	void Start (){

		pn = PlayerPrefs.GetInt ("pnn");
		p = m.players;
	}

	void Update () {

		for (int i = 0; i < pn ; i++) {

			player pi = p [i].GetComponent<player> ();

			int b = pi.balance;


			switch (i) {

			case 0:
				t1.text = b.ToString ();
				break;
			case 1:
				t2.text = b.ToString ();
				break;
			case 2:
				t3.text = b.ToString ();
				break;
			case 3:
				t4.text = b.ToString ();
				break;
			
					}
		
			}
		}
}
