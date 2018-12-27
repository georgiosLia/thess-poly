using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getnumpl : MonoBehaviour {


	public Dropdown d1;
	public GameObject p3, p4;
	public int n=0;

	public void getpn(){

		PlayerPrefs.SetInt ("pnn", 2);

		p3.SetActive (false);
		p4.SetActive (false);

		n = d1.value;

		if (n == 1) {

			p3.SetActive (true);
			PlayerPrefs.SetInt ("pnn", 3);
		}

		if (n == 2) {
			
			PlayerPrefs.SetInt ("pnn", 4);
			p3.SetActive (true);
			p4.SetActive (true);

		}

	}
}
