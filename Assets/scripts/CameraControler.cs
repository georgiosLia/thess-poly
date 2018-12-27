using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Elegxei thn camera otan akolouthei ton apixti
public class CameraControler : MonoBehaviour {

    //O paiktis ston opoio koitazei h camera
    public GameObject player;
    public Transform target;
    public Vector3 offset;  //h diafora tou dianismatos tou paixti kai tis cameras pou ton koitaei
    public Vector3 rotationOffset;  //H diafora peristrofis
    public float smoothing = 5f;    //H omalotita kinisis tis cameras
    public float rotationSmoothing = 5f; //h omalotita peristrofis

    // Use this for initialization
    void Start () {
        //offset = new Vector3(0.2177f,2.5f,1.97f);//transform.position - target.position;
        //rotationOffset = new Vector3(55.000f,180f,0f);//transform.rotation.eulerAngles - target.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate() // to LateUpdate xrismimopoieitai gia tin camera, sto telos tou kathe Frame, orizei thn kaoinouria thesi tis
    {
        Vector3 targetCamPos = target.position + (target.rotation * offset);

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime); //Orizei tin thesi tis cammeras omala mesw tou
                                                                                                         //smoothing * Time.deltaTime
        //Vector3.RotateTowards(target.rotation.eulerAngles, rotationOffset, 10f * Time.deltaTime, 0.0F);
        //transform.LookAt(target);
        //transform.position = target.transform.position + offset;

        Quaternion toRot = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion curRot = Quaternion.Slerp(transform.rotation, toRot, rotationSmoothing);
        transform.rotation = curRot;
    }
}
