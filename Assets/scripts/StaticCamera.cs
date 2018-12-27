using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//H statiki camera pou xismimevei na na koitazei se ena stathero simeio giogra, einai orismeni arxika gia ta zaria
public class StaticCamera : MonoBehaviour {

    public float smoothing = 5f;
    public float rotationSmoothing = 5f;
    
    public Vector3 Posisition;
    public Vector3 Rotation;


    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = Vector3.Lerp(transform.position, Posisition, smoothing * Time.deltaTime);
        //Vector3.RotateTowards(target.rotation.eulerAngles, rotationOffset, 10f * Time.deltaTime, 0.0F);
        //transform.LookAt(target);
        //transform.position = target.transform.position + offset;

        //Quaternion toRot = Quaternion.LookRotation(location.position - transform.position, location.up);
        Quaternion curRot = Quaternion.Slerp(transform.rotation,Quaternion.Euler(Rotation), rotationSmoothing);
        transform.rotation = curRot;
		
	}
}
