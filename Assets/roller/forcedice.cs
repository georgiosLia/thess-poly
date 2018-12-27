using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forcedice : MonoBehaviour {

	public float fA = 10.0f;
	public ForceMode fm;
	public float tA = 10.0f;
 	

	public void gf(){

		Rigidbody rb = GetComponent<Rigidbody>();

		rb.AddForce (Random.onUnitSphere * fA, fm);
		rb.AddTorque (Random.onUnitSphere * tA, fm);
	//	Rigidbody.AddForce (Random.onUnitSphere * fA, fm);
	//	Rigidbody.AddTorque (Random.onUnitSphere * tA, fm);
	}
}
