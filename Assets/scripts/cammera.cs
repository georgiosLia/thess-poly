using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cammera : MonoBehaviour {

    //[SerializeField]
    private Transform target;
	[SerializeField]
	private Vector3 offsetPosition;
	[SerializeField]
	private Space offsetPositionSpace = Space.Self;
	private bool lookAt = true;
	int a=0;
	private GameObject p1;

	private void Update()
	{
	//	p1 = GameObject.Find("p1(clone)");

	//	p1.gameObject.SetActive (false);

		//p1 = GameManager.gp ();

		target = p1.transform;

		Refresh();

		if (target.transform.position.x > 6 && a==0) {
				
			target.Rotate (-90, 90, 0);
			a = 1;
		}
	}

	public void Refresh()
	{
		/*int n = PlayerPrefs.GetInt ("pwp");

		int[] paa = new int[4];

		paa = getppiece.pa;

		switch (paa [n]) {

		case 1:
			offsetPosition = offsetPosition+ new Vector3( 0f, 35f, 51f);

			break;
		case 2:
			offsetPosition = offsetPosition+new Vector3( 0f, 1049f, 1350f);
			break;
		case 3:
			offsetPosition =offsetPosition+new Vector3( 0f, 1.43f,1.89f);
			break;
		case 4:
			offsetPosition =offsetPosition+new Vector3( 0f, 1.89f, 1.65f);
			break;
		case 5:
			offsetPosition =offsetPosition+new Vector3( 0f, 19.8f, 19.5f);
			break;
		case 6:
			offsetPosition =offsetPosition+new Vector3( 0f, 1.71f, 1.68f);
			break;

		}*/

		
		// compute position
		if(offsetPositionSpace == Space.Self)
		{
			transform.position = target.TransformPoint(offsetPosition);
		}
		else
		{
			transform.position = target.position + offsetPosition;
		}

	

		// compute rotation
		if(lookAt)
		{
			transform.LookAt(target);
		}
		else
		{
			transform.rotation = target.rotation;
		}
	}




}
