using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To script pou koumpwnei ousiastika se kathe gameObject tetragwnou kai tou dinei tis idiotittes tou tetragwnou
public class square : MonoBehaviour {

	public int sqid; //To id tou tetragwnou
	public int side; //H plevra pou vrisketai to twtragwno sto tablo, xreiazetai kyriws gia thn kamera kai thn katefthinsh tou paikth
	public List<GameObject> players; //Oi paiktes pou vriskontai kathe fora sto tetragwno, ta gameObject tous
	public card sq_card;//H karta pou antistoixei
    static public List<square> sq_list = new List<square>();
    public Transform path_p1;   //To path pou xrisimopoiei o paixtis gia na kinithei, pros to paron yparxei idio path gia olous tous paixtes
    public square nextSq;       //To epomono tetragwno, etsi dimeiourgeitai mia sindemeni lista me to kathe tetragwno na kserei to epomeno tou,
                                //etsi ylopoieitia kai o tropos kinisi sotu paixti me tin dimiourgia monopatiou apo tetragwna

    public GameObject HousePrefab;  //to montelo tou spitiou
    public GameObject HotelPrefab;  //To montelo tou ksneadoxeiou

    public List<Vector3> HousesPoints;  //den leitourgeoun akoma... xrismiopoihtikan stpitia protopotheitmena
    public Vector3 HotelPoint;

    public int HousesBuilt; //Arithmos kswnadoxeiwn pou exoun xtisetei
    public List<GameObject> Houses; //Ta spitia pou yparxoun kai einai anenerga stin arxi 
    public int HotelBuilt;  //Ksenadoxeia pou exoun kstisei, arithmos
    public GameObject Hotel;    //To ksenadoxeio pou den fainetai mexri na ginei ernergo otan agorastei 

	// Use this for initialization
	void Start () {
		//print ("Square " + sqid + " initialized");
        //path_p = transform.FindChild("p_point");


        sq_list.Add(this);

        

        HotelBuilt = 0;
        HousesBuilt = 0;

        //SetUp();
        //path_p = 
    }

    public int SetUp()  //Arxikopoihsh metavlitwn tou tetragwnou
    {
        
        Houses = new List<GameObject>();

        for (int i = 0; i < 4; i++)
        {
            GameObject TempHouse = gameObject.transform.Find("House" + (i + 1)).gameObject;
            if (TempHouse != null)
            {
                TempHouse.SetActive(false);
                Houses.Add(TempHouse);
            }
        }

        Hotel = gameObject.transform.Find("Hotel").gameObject;
        Hotel.SetActive(false);
        return 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Build() //Xtisimo, xtizei spitia kai otan exoun xtistei ola ta spitia xtizei ksenadoxeio eksafanizotnas ta spitia
                        //o elegxos pragmatopoieitai apo to mesai epipedo mesw tis idioktisias property
    {
        if(HousesBuilt < 4)
        {
            Houses[HousesBuilt].SetActive(true);    //Energopoieitai to epomeno spiti
            HousesBuilt++;                          //Afksanetai o deikths pou afora ton arithmo spitiwn sto siggekrimeno tetragwno

        }
        else
        {

            foreach (GameObject H in Houses) H.SetActive(false); //Apenergopoioi prwta ta spitia kai meta energopoiei to ksenadoxeio

            HotelBuilt++;                           //Afksanetai o deiktis pou deixnei oti yparei ksenadoxeio
            Hotel.SetActive(true);                  //Edw energopoieitai to ksenadoxeio
        }
    }

}
