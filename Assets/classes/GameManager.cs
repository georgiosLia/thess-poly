using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //public static GameManager gm;
    public int num_players;     //o Arithmos twn paixtwn pou paizoun, keimenetai apo 2-4 
    public int PlayersActive;   //Oi energoi paixtes, dialdi autoi pou exoun xasei, xrisimopoieitai gia ton elegxo tou nikiti

    public TableManager t_manager;  //o Table manager tou paixnidiou pai elegxei tis leitourgeies pou sxetizontai me to tabmplo kai ta tetragwna
                                    //Xrisimevei sto na min ginei o gameManager polli megali class, diaxwrizei tis leitourgies
    
    public GameObject[] players;    //Ta antikeimena gameObject twn paixtwn pou paizoun authn tin stigmi
    public GameObject[] player_prefabs;//Ta prefab twn paixtwn
    public static GameObject[] pl;
    public CardList cardListAsset;  //To asset me tis kartes pou exoun dimiourgithei mesw tou CreateCardList, periexei ena antikeimeno typou CardList
                                    //Mesa sto opoio periexontai oi perissoteres Kartes idioktisiwn kai Leitourgeiwn SpecialCards

    public GameObject HousePrefab;  //To prefab - montelo tou spitiou pou xtizetai
    public GameObject HotelPrefab;  //To prefab - montelo tou ksenadoxeiou pou xtizetai

    public List<SpecialCard> apofasi;   //H lista me tis kartes apofasis
    public List<SpecialCard> entoli;    //H lista me tis kartes entolis

    public Stack<SpecialCard> apofasiStack; //H stoiva me tis kartes apofasis, mesa apo tin stoixva tha travaei karta o paixtis
    public Stack<SpecialCard> entoliStack;  //H stoiva me tis kartes entolis, mesa apo tin stoixva tha travaei karta o paixtis

    //public Sprite[] cardimages;             
    //private List<square> squares;
    public Image cardimage;
    public CameraControler cc;  //O CameraController o opoios elegxei thn camera oson afora ton paixti
    public Text MessageText;    //To antikeimeno text sto opoio emfanizontai ola ta minimata stin othoni
    
    public GameObject b;
    public GameObject canvas;   //To canvas sto opoio einai ola ta antikeimena GUI (koumpia, plaisia eimenou)
    public UIManager uiManager; //O UIManager o opoios xrisimopoieitai gia na eksatomikeftous orismenes leitourgies GUI, voithaei sto na min einai
                                //o kwdikas tou GameManager epifortismenos me tetoia stoixeia elegxou
    public List<Property> properties;   //H lista me olas tis idioktisies tou paixnidiou, ta antikeimna typou property
    public GameObject mortm;
    public GameObject pref;

    public int steps = 1;       //Xristimopoieitai gia debugging, elexgei tin kinisi tou paixti aneksartita apo ta zaria
    

    // Use this for initialization
    void Start()
    {
        //GameManager.gm = this;
        PlayersActive = 0;          //Arxikopoiei tous energous paixtes
        uiManager.SetUp(this);      //Arxikopoiei ton UIManager
        
        cardListAsset = Resources.Load<CardList>("CardList");                           //Fortwnei to asses me to CardList


        
        
        t_manager.setUp(this);          //Axikopoiei ton TableManager

        foreach (GameObject sq in t_manager.squares)        //Arxikopoiei to mondelo tou spitiou kai tou ksenadoxeiou sto kathe square - tetragwno
        {
            sq.GetComponent<square>().HousePrefab = HousePrefab;
            sq.GetComponent<square>().HotelPrefab = HotelPrefab;
            //for (int i = 0; i < 5; i++) sq.GetComponent<square>().Build();
        }

        spawnPlayers();             //Ektelei tis entoles emfanisis kai arxikopoihshs tou kathe paixti
        //print("spawnPlayers called");
        num_players = PlayerPrefs.GetInt("pnn");    //Enimerwnei ton arithmo paixtwn
        Array.Resize(ref players, num_players);     


        properties = cardListAsset.cardList;    //Diavazei tis idioktisies kai tis pernaei stin lista me tis kartes
        List<card> cards = new List<card>();    

        foreach (card c in properties)
        {
            (c as Property).CanBuilt = true;
            (c as Property).homesbuilt = 0;
            (c as Property).hotelsbuilt = 0;
            cards.Add(c);

        }

        List<SpecialCard> specialCards = createSpecialCards();//Edw dimiourgei tis kartes leitourgeiwn kai tis pernaei stin lista me tis kartes
        PrepareSpecialCards(specialCards);

        foreach (card c in specialCards)
        {
            cards.Add(c);
        }

        List<Property> SpecialProperties = CreateSpecialProperties();
        foreach (card c in SpecialProperties)
        {
            cards.Add(c);
        }

        //Edw mpainei h kathe karta stin swsti thesi analoga me to tetragwo pou tairazei
        foreach (card c in cards)
        {
            foreach (GameObject s in t_manager.squares)
            {
                if (s.GetComponent<square>().sqid == c.sqid)
                {
                    s.GetComponent<square>().sq_card = c;
                    c.CardSquare = s.GetComponent<square>();
                    //print("card " + c.id + " assigned to square " + s.name);
                    break;
                }
            }
        }

        foreach(GameObject sq in t_manager.squares)
        {
            if((sq.GetComponent<square>().sq_card is Property) && ((Property)sq.GetComponent<square>().sq_card).CanBuilt)
                sq.GetComponent<square>().SetUp();
        }

        foreach(GameObject sq in t_manager.squares)
        {
            square sqq = sq.GetComponent<square>();
            if (sqq.sq_card is Property)
            {
                if(((Property)(sqq.sq_card)).CanBuilt)
                {
                    sqq.SetUp();
                }
            }
        }

        //Dimiourgountai oi stoives me tis kartes apofasis kai entolis
        apofasiStack = new Stack<SpecialCard>(apofasi);
        entoliStack = new Stack<SpecialCard>(entoli);

        //edw ksekinaei to paixnidi, mpainei h camera ston prwto paixti 
        cc.target = players[0].GetComponent<player>().transform;

        
        //Cheats(); //<-- to cheats xrisimopoeieitai gia debugging, na elegxthoun orismenes leitourgies ypo orismenes sinthikes
                        //opws agorasmenes idioktisies, lefta, spitia


        StartCoroutine(GameLoop()); //<-- Edw ksekinaei ousiastika to gameLoop mesw Cooroutine, gia na mporei na ginetai h diaxeirisi tou xronou
                                    //kai na yparxoun diakopes sthn roh tou kwdika

        
    }

    void Cheats()   //H sinartisi cheats gia debugging
    {
        player pl = players[0].GetComponent<player>();
		player pl2 = players[1].GetComponent<player>();
        pl.balance = 99999999;

        pl.BuyProperty(t_manager.squares[12].GetComponent<square>().sq_card as Property);
        pl.BuyProperty(t_manager.squares[5].GetComponent<square>().sq_card as Property);
        pl.BuyProperty(t_manager.squares[35].GetComponent<square>().sq_card as Property);
        pl.BuyProperty(t_manager.squares[15].GetComponent<square>().sq_card as Property);
        pl.BuyProperty(t_manager.squares[1].GetComponent<square>().sq_card as Property);
        pl.BuyProperty(t_manager.squares[3].GetComponent<square>().sq_card as Property);

		pl2.BuyProperty(t_manager.squares[6].GetComponent<square>().sq_card as Property);
		pl2.BuyProperty(t_manager.squares[8].GetComponent<square>().sq_card as Property);

        pl.balance = 99999999;
		pl2.balance = 10;

    }


    // Update is called once per frame
    void Update()
    {


        
    }

    private void PrepareSpecialCards(List<SpecialCard> list)
    {
        apofasi = new List<SpecialCard>();
        entoli = new List<SpecialCard>();
        List<SpecialCard> otherCards = new List<SpecialCard>();

        //Oi entoles kai oi apofaseis mpainoun stin katallili lista
        foreach (SpecialCard card in list)
        {
            if (card.cardType.Equals(SpecialCard.APOFASI)) apofasi.Add(card);
            else if (card.cardType.Equals(SpecialCard.ENTOLI)) entoli.Add(card);
            else otherCards.Add(card);
        }

        //oi ypoloipes kartes mpainoun sto analogo tetragwno pou tis analogei opws h fylaki, oi foroi
        foreach (card c in otherCards)
        {
            t_manager.squares[c.sqid].GetComponent<square>().sq_card = c;
        }
    }



    //    private List<card> createSpecialCards()
    //  {

    //}


    private void spawnPlayers() //Emfanizei tous paixtes sot tamplo kai voithatei sthn arxikopoihsh twn etavitwn tous
    {

        int[] paa = new int[4];

        paa = getppiece.pa;

        //print(paa[0]);
        //print(paa[1]);
        //print(paa[2]);
        //print(paa[3]);

        int np = PlayerPrefs.GetInt("pnn");


        for (int i = 0; i < np; i++)
        {
            int pf = paa[i];
            players[i] =
               Instantiate(player_prefabs[pf], t_manager.path_points[0].GetComponent<Transform>().position, t_manager.path_points[0].GetComponent<Transform>().rotation) as GameObject;
            players[i].GetComponent<player>().setTableManager(t_manager);
            //print(squares[0].name);
            players[i].GetComponent<player>().SetUp(i, t_manager.squares[0].GetComponent<square>(),this);
            players[i].GetComponent<player>().playerNo = i;
            PlayersActive++;
        }

        pl = players;


    }

    

    
    //H yporoutina pou ekteleitai otan teleiwsei to paixnidi
    private IEnumerator OnGameEnding()
    {
        //Elegxei poios paixtis einai nikistis kai emfanizei to analogo minima stin othoni
        GameObject WinnerPlayer = null;
        foreach(GameObject p in players)
        {
            if (p.GetComponent<player>().playerInGame)
            {
                WinnerPlayer = p;
                break;
            }
        }

        cc.target = WinnerPlayer.transform;

        yield return DisplayMessageForSeconds("Player " + WinnerPlayer.GetComponent<player>().playerNo + " is the Winner!!!", 5);
        StopAllCoroutines();
    }

    //H kyria epanalipsi tou paixnidiou, ekteleitai stin arxi tou kathe gyrou, otan teleiwsoun oloi oi paixtesthn seira tous
    // edw einai to kentro pou elegxetai to paixnidi
    private IEnumerator GameLoop()
    {
        //starting the game
        

        yield return DisplayMessageForSeconds("new Round");
        foreach (GameObject currPlayerObject in players)
        {
            //Elegxos stamatimatos, an parxei nikitis
            if (PlayersActive < 2)
            {
                print("Now the game stops");
                yield return OnGameEnding();
            }

            //anoixe to koumpi zaria

            //PlayerPrefs.SetInt ("pwp", 1);

            //int n = PlayerPrefs.GetInt ("pwp");

            //Allazei o apixtis kai h cammera
            player currPlayer = currPlayerObject.GetComponent<player>();
            cc.target = currPlayerObject.GetComponent<Transform>(); //Allagi paixti tis cameras



            //Edw vazoume thn camera na koitaei ton paixti pou paizei
            if (currPlayer.playerInGame == false) continue;
            yield return DisplayMessageForSeconds("Now playing player " + (currPlayer.playerNo + 1));
            //rixnoume zaria edw kai pernoume tous arithmous

            //Mesw tou TableManager elegxetai h diadikastia ripsisi twn zariwn mesw Cooroutine
            yield return StartCoroutine(t_manager.ThrowDice());


            int x = PlayerPrefs.GetInt("d1");//steps; <-- Autes oi entoles xrisimopoiountai gia degbug, elegxoun tin kinisi tou paixti
            int y = PlayerPrefs.GetInt("d2");//0;// <--   Aneksartita apo ton arithmo twn zariwn

            

            yield return null;

            //Elegxos an o paixtis einai sthn fyalki, elegxei tous gyrous pou einai sthn fylaki kai den ton afinei na katsei panw apo 3 gyrous
            if(currPlayer.RoundsInJail >= 3)
            {
                yield return DisplayMessageForSeconds("You are in jail 3 rounds in a row\n you pay 50 bucks and get out");
                currPlayer.Pay(50);
                currPlayer.inJail = false;
                currPlayer.RoundsInJail = 0;
            }
            if (currPlayer.inJail)
            {
                
                if (x == y)
                {
                    print("same dice " + currPlayer.name + " out of jail");
                    yield return DisplayMessageForSeconds("same dice" + (currPlayer.playerNo + 1) + " out of jail",2f);
                    currPlayer.inJail = false;
                    currPlayer.RoundsInJail = 0;
                    continue;
                }
                else
                {
                    yield return DisplayMessageForSeconds("diffrent dice " + (currPlayer.playerNo + 1) + " still in jail", 2f);
                    yield return uiManager.JailPayWindow(currPlayer);
                    if (currPlayer.inJail)
                    {
                        yield return DisplayMessageForSeconds("Player " + (currPlayer.playerNo + 1) + " still in jail", 2f);
                        currPlayer.RoundsInJail++;

                    }
                    continue;
                }
            }

            //Edw kineitai o paixtis, ragmatopoieitai h kinisi tou simfwna me ta zaria tou paixti
            t_manager.MovePlayer(currPlayer, x + y);
            while (currPlayer.OnMove)   //Perimenei na teleiwsei h kinisi tou paixti gia na sinexisei h ektelesi tou kwdika
            {
                yield return null;
            }

            card currSqCard = currPlayer.currentSquare.sq_card; //Pernoume tin karta pou antistixei sto tetragwno kai elegxoume simfwna me authn ama
                                                                //o paixtis epese se idioktisia h se SpecialCard
            print("Player on square " + currPlayer.currentSquare + " with card " + currSqCard.picture);
            if (currSqCard is Property) //An epese o paixtis se idioktisia
            {
                //print("player " + currPlayer.playerNo + " is on Property square");
                yield return DisplayMessageForSeconds("player " + (currPlayer.playerNo + 1) + " on Property square " + currSqCard.picture);
                //edw ektelountai oi energeies sthn idioktisia analoga se poion anikei kai tetoia
                

                //Edw ksekinaei to cooroutine pou afora ton xeirismo idioktisias
                yield return OnProperty((Property)currSqCard, currPlayer);

            }
            else if (currSqCard is SpecialCard) //An o paixtis epese se karta leitourgeias - SpecialCard
            {
                print("player " + (currPlayer.playerNo + 1) + " is on Special square");
                yield return DisplayMessageForSeconds("player " + (currPlayer.playerNo + 1) + " on Special square");
                yield return (currSqCard as SpecialCard).callActionScript(this, currPlayer); // Ektelountai oi analoges energeies tin kartas
                
            }

            yield return OnPlayerTurnEnding(currPlayer);// <-- oi entoles pou ektelountai otan teleiwsei o gyros tou kathe paixti, mileitourgiko
            yield return StartCoroutine(WaitForKeyDown(KeyCode.Space, "press 'space' to continue..."));

			// OnPlayerTurnEnding(currPlayer);

            //Edw exei kinithei o paixtis kai exei kataliksei sto tetragwno 

            //n++;

            //PlayerPrefs.SetInt ("pwp", n);

        }

	

        //edw elegxoume ama yparxei nikitis kai tetoia, meta kaskiname pali apo tin arxi kalontas ksana to loop
        StartCoroutine(GameLoop());
    }

    private IEnumerator OnPlayerTurnEnding(player currPlayer)
    {
        if (currPlayer.balance <= 0)
        {

            /*if (currPlayer.allMortage() == false)
            {
                //edw trexei h epilogi gia motage kai tetoia
				getmortage(currPlayer);
                
            }*/
            if (currPlayer.balance <= 0)
            {
                //you loose mtishgiofdsohi
                yield return DisplayMessageForSeconds("you lose ");
                currPlayer.PlayerLost();
            }
        }
        

    }

    //Xrisimevei gia tin pafsi mia routinas me sinthiki ena pliktro kai proeraitiko minima
    IEnumerator WaitForKeyDown(KeyCode keyCode, string displayMessage = null)
    {
        if (displayMessage != null)
        {
            MessageText.text = displayMessage;
            b.SetActive(true);
            MessageText.enabled = true;
        }
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        MessageText.enabled = false;
        b.SetActive(false);
    }

    //Xrismimevei stin pafsi mia routinas kai tin provoli enos minimatos gia orismeno xrono pou mporei na allksei kai apo ton xristi, idietaira xrisimi
    public IEnumerator DisplayMessageForSeconds(String text, float time = 1f)
    {
        MessageText.text = text;
        b.SetActive(true);
        MessageText.enabled = true;
        yield return new WaitForSeconds(time);
        MessageText.enabled = false;
        b.SetActive(false);
    }


    //H routina pou xeirizetai to paixnidi otan o paixtis vrisketai se idioktisia
    public IEnumerator OnProperty(Property currcard, player currpl)
    {

        if (currcard.owner == currpl) //An katexei tin idioktisia kai ta alla xromata tou dinetai h dinatotita na xtisei ksenadoxeio mesw parthirou tou UImanger
        {
            print("Buy house or hotel");
            // an exe ita alla apo to idio xrwma
            if (currcard.AllColoursBought(this, currpl))
            {

                yield return uiManager.BuyHouseHotelWindow(currcard, currpl);
            }
            //alliws tpt

        }
        else if (currcard.owner == null) //An den anikei se kanenan h idioktisia tote mporei na tin agwrasei mesw tou parathirou agoras tou UIManager
        {
            //emfanise to gm kai ta koumpia
            yield return uiManager.BuyPropertyWindow(currcard, currpl);

        }
        else //Alliws anikei se kapoion h idioktisia kai plirwnei analoga me to poso pou ypologizetiai analoga me tis karta idioktisias
        {
            //bres se poion anikei kai plirwse
            int pay = currcard.GetPayAmount(t_manager);
            currpl.Pay(pay, currcard.owner);
            yield return DisplayMessageForSeconds("Player " + (currpl.playerNo + 1) + " pay " + pay + " to player " + (currcard.owner.playerNo + 1), 2.5f);
            print("Player " + (currpl.playerNo + 1) + " pay " + pay + " to player " + (currcard.owner.playerNo + 1));
        }
        yield return null;
    }

    public void getmortage(player currpl) { // mi leitourgiko kommati akoma... Aofra tis ypothikes

		//3ekinaei anoigontas to menu
        mortm.SetActive(true);

        Button nb;
		Button[] ab = new Button[12];
        GameObject tb;
        Vector3 bdpc = new Vector3(0f, -55f, 0f);
        Vector3 brpc = new Vector3(280f, 0f, 0f);
        Vector3 bpc = new Vector3(0f, -55f, 0f);
        player pl = currpl;
		int i = 0;
		//blepeis oles tis idiktisies tou paikti kai
		//dimiourgei tosa koubia osa einai kai oi idioktisies tou
		//sta if topo9etei swsta ston xwro ta koubia
		foreach(Property c in pl.properties) {
			int n = 0;
            tb = (GameObject)GameObject.Instantiate(pref);
            nb = tb.GetComponent<Button>();
            nb.transform.SetParent(mortm.transform, false);
			nb.GetComponentInChildren<Text> ().text = c.picture;
			ab [n] = nb;
			if (n > 6) {
                nb.transform.position = nb.transform.position + brpc;
                nb.transform.position = nb.transform.position + bpc;
                bpc = bpc + new Vector3(0f, -55f, 0f);
            } else {
                nb.transform.position = nb.transform.position + bdpc;
                bdpc = bdpc + new Vector3(0f, -55f, 0f);
            }
			n ++;
        }
		//bazei akomia mia idiotita gia tin ypo8iki
		foreach (Button b in ab) {

			b.onClick.AddListener (delegate{addl(pl, i);});
				i++;
			}

		while (pl.balance <= 0) {
			mortm.SetActive(true);
		}
		mortm.SetActive(false);
		return;
    }

	private void addl(player p, int i){

		p.properties [i].setMortage ();
	}

    private List<SpecialCard> createSpecialCards() //H sinartisi dimiourgias twn SpecialCards - den fortwnontai swsta apo to asset kai logo 
                                                   //periporismou ta kaname hardcode edw
    {
        List<SpecialCard> list = new List<SpecialCard>();


        list.Add(new SpecialCard("apofasi1", 23, -1, SpecialCard.APOFASI, new gotoblue2()));
        list.Add(new SpecialCard("apofasi2", 24, -1, SpecialCard.APOFASI, new add50()));
        list.Add(new SpecialCard("Entoli1", 25, -2, SpecialCard.ENTOLI, new goback3()));
        list.Add(new SpecialCard("Entoli2", 26, -2, SpecialCard.ENTOLI, new Pay15()));
        list.Add(new SpecialCard("gotoJail_s", 27, 30, "", new gotoJail()));
        list.Add(new SpecialCard("Entoli_s1", 28, 7, "", new Entoli()));
        list.Add(new SpecialCard("Entoli_s2", 29, 22, "", new Entoli()));
        list.Add(new SpecialCard("Entoli_s3", 30, 36, "", new Entoli()));
        list.Add(new SpecialCard("Apofasi_s1", 31, 2, "", new Apofasi()));
        list.Add(new SpecialCard("Apofasi_s2", 32, 17, "", new Apofasi()));
        list.Add(new SpecialCard("Apofasi_s3", 33, 33, "", new Apofasi()));
        list.Add(new SpecialCard("Tax1_s", 34, 4, "", new Tax1()));
        list.Add(new SpecialCard("Tax2_s", 35, 38, "", new Tax2()));
        list.Add(new SpecialCard("apofasi3", 36, -1, SpecialCard.APOFASI, new Pay50()));

        list.Add(new SpecialCard("Entoli99", 99, -2, SpecialCard.ENTOLI, new gotoJail()));

        return list;
    }

    private List<Property> CreateSpecialProperties()  //Edw dimiourgountai oi idioktisies stathmwn kai ypirasiwn oi opoies exoun idietairi diaxeirisi
    {
        List<Property> SpecialProperties = new List<Property>();

        Property p = new Property("TrainStation1", 200, -1, -1, 100, -1, -1, -1, -1, -1, -1, -1, 5, Resources.Load<Sprite>("texture/kartes_idioktisiwn/25"));
        p.payScript = new TrainStationPay();
        p.payScript.Owner = null;
        p.CanBuilt = false;
        SpecialProperties.Add(p);

        p = new Property("TrainStation2", 200, -1, -1, 101, -1, -1, -1, -1, -1, -1, -1, 15, Resources.Load<Sprite>("texture/kartes_idioktisiwn/23"));
        p.payScript = new TrainStationPay();
        p.payScript.Owner = null;
        p.CanBuilt = false;
        SpecialProperties.Add(p);

        p = new Property("TrainStation3", 200, -1, -1, 102, -1, -1, -1, -1, -1, -1, -1, 25, Resources.Load<Sprite>("texture/kartes_idioktisiwn/24"));
        p.payScript = new TrainStationPay();
        p.payScript.Owner = null;
        p.CanBuilt = false;
        SpecialProperties.Add(p);

        p = new Property("TrainStation4", 200, -1, -1, 103, -1, -1, -1, -1, -1, -1, -1, 35, Resources.Load<Sprite>("texture/kartes_idioktisiwn/26"));
        p.payScript = new TrainStationPay();
        p.payScript.Owner = null;
        p.CanBuilt = false;
        SpecialProperties.Add(p);

        p = new Property("Service1", 150, -1, -1, 104, -1, -1, -1, -1, -1, -1, -1, 12, Resources.Load<Sprite>("texture/kartes_idioktisiwn/27"));
        p.payScript = new ServicesPay();
        p.payScript.Owner = null;
        p.CanBuilt = false;
        SpecialProperties.Add(p);

        p = new Property("Service2", 150, -1, -1, 105, -1, -1, -1, -1, -1, -1, -1, 28, Resources.Load<Sprite>("texture/kartes_idioktisiwn/28"));
        p.payScript = new ServicesPay();
        p.payScript.Owner = null;
        p.CanBuilt = false;
        SpecialProperties.Add(p);


        return SpecialProperties;
    }



}
