using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To script kinisis tou paixti, elegxei pws tha kinithei o paixtis mesa ston xwro
public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;   //Taxitita tou paixti
    public square target;       //O stoxos pou thelei na ftasei
    public square currSq;       //To tatragwno pou vrisketai twra o apixtis
    public player playerScript; //to script player pou anaparista tis idiotites tou paixti

	// Use this for initialization
	void Start () { //Arxikopoihsh metavlitwn kai thesis
        playerScript = GetComponentInParent<player>();
        target = GetComponentInParent<player>().currentSquare;
        currSq = target;
	}
	
	// Update is called once per frame
	void FixedUpdate () {   //FixedUpadate gia tin statheri kinisi tou paiti ana Frame kai oxi simfwna me to roloi CPU


        if (currSq != target) //kinisi mexi na ftasei o paixtis ston stoxo
        {
            playerScript.OnMove = true;
            transform.position = Vector3.MoveTowards(transform.position, currSq.nextSq.path_p1.transform.position, speed * Time.deltaTime);
            //transform.Rotate(currSq.nextSq.path_p1.transform.rotation.eulerAngles);
            if (transform.rotation != currSq.path_p1.transform.rotation) transform.rotation = currSq.path_p1.transform.rotation;
            if ((Vector3.Distance(transform.position, currSq.nextSq.path_p1.position) < 0.1f) && (currSq != target))
            {
                currSq = currSq.nextSq;
                GetComponentInParent<player>().currentPos = currSq.sqid;
                if(currSq.sq_card is SpecialCard)
                {
                    //((SpecialCard)currSq.sq_card).actionScript.OnPassthrough(); <-- edw tha empainan oi enargeies ths specialcard otan pernaei o paixtis

                }
            }
        }
        else
        {
            playerScript.OnMove = false; //Otan stamataei na kineitai allazei h metavliti gia na sinexisei to programma na trexei meta to telos tis kinisis
        }
        


        /*if (transform.position != target.position)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }*/
    }
}
