using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gdresults : MonoBehaviour {

	private int d1, d2 , ds;
	public Text t1;
	
	// Update is called once per frame
	void Update () {

		d1 = PlayerPrefs.GetInt ("d1");
		d2 = PlayerPrefs.GetInt ("d2");

		ds = d1 + d2;
	

		t1.text = " d1: " + d1.ToString() + " d2: " + d2.ToString() + " sum: " + ds.ToString();


	}
		
}
