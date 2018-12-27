using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getppiece : MonoBehaviour {

	public Dropdown d1, d2, d3, d4;
	public GameObject p3t, p4t;
	public static int [] pa;
	private int pna;
    public GameManager gm;

	public void getpp(){

		pa = new int [4];

		pna = PlayerPrefs.GetInt ("pnn");

		switch (d1.value) {

		case 1:
			pa [0] = 1;
			break;
		case 2:
			pa [0] = 2;
			break;
		case 3:
			pa [0] = 3;
			break;
		case 4:
			pa [0] = 4;
			break;
		case 5:
			pa [0] = 5;
			break;
		case 6:
			pa [0] = 6;
			break;
		}

		switch (d2.value) {

		case 1:
			pa [1] = 1;
			break;
		case 2:
			pa [1] = 2;
			break;
		case 3:
			pa [1] = 3;
			break;
		case 4:
			pa [1] = 4;
			break;
		case 5:
			pa [1] = 5;
			break;
		case 6:
			pa [1] = 6;
			break;
		}

		if ( pna == 3) {
			switch (d3.value) {

			case 1:
				pa [2] = 1;
				break;
			case 2:
				pa [2] = 2;
				break;
			case 3:
				pa [2] = 3;
				break;
			case 4:
				pa [2] = 4;
				break;
			case 5:
				pa [2] = 5;
				break;
			case 6:
				pa [2] = 6;
				break;
			}

			p3t.SetActive (true);
		}

		if (pna == 4) {

			switch (d3.value) {

			case 1:
				pa [2] = 1;
				break;
			case 2:
				pa [2] = 2;
				break;
			case 3:
				pa [2] = 3;
				break;
			case 4:
				pa [2] = 4;
				break;
			case 5:
				pa [2] = 5;
				break;
			case 6:
				pa [2] = 6;
				break;
			}


			switch (d4.value) {

			case 1:
				pa [3] = 1;
				break;
			case 2:
				pa [3] = 2;
				break;
			case 3:
				pa [3] = 3;
				break;
			case 4:
				pa [3] = 4;
				break;
			case 5:
				pa [3] = 5;
				break;
			case 6:
				pa [3] = 6;
				break;
			}

			p3t.SetActive (true);
			p4t.SetActive (true);
		}
			
	}
}
