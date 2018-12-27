using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Klassi pou anaparista ton paixti kai tis leitourgeies tou mesa sto paixnidi 
public class player : MonoBehaviour {

    public int playerNo;    //o Arithmos tou paixti 
	public int balance;//Ta lefta tou kathe paikth
	public List<Property> properties; //oi kartes idioktisiwn tou paikth
	public int currentPos;//H thesh tou paikth panw sto tamplo
	private PlayerMovement m_player;//To script ths kihshs tou paikth
    [HideInInspector] public GameObject m_Instance;
    public TableManager t_manager;
    private GameManager gm;
    public square currentSquare;    //To tetragwno pou vrisketai authn thn stigmi o paixtis
    public bool inJail;             //An vrisketai sthn fylaki
    public bool OnMove;             //An kineitai o paixtis, xrisimevei gia tin pafsi kata tin kinisi
    public bool playerInGame;       //An o paixtis einai energos sto paixnidi h exie xasei
    public int RoundsInJail;        //Posoun gyrous sinexomena vrisketai sthn fylaki

    public void addMoney(int amount)    //Prosthiki ximatwn sto balance
    {
        balance += amount;
    }

    public bool IsProperty(card CurCard)    //Elegxei an mia idioktisia anikei ston paixti
    {
        foreach(card c in properties)
        {
            if (CurCard.Equals(c)) return true;
        }
        return false;
    }

    

    public void Pay(int amount, player to = null)   //Sinartisi plirwmis, an prokeite gia polirwmi se paixti simplirwnetai o proeraitikos paixtis player
    {
        this.addMoney(-amount);
        if (to != null)
        {
            
            if(to.playerInGame)
            {
                to.addMoney(amount);
            }
        }
    }

    // Use this for initialization
    void Start () {
        
        
        
    }

    public bool allMortage()    //Elegxei an oles oi idioktisies tou eina pothikevmenes
    {
        foreach(Property p in properties)
        {
            if (p.isMortage == false) return false;
        }
        return true;
    }

    public void SetUp(int playerNo, square start, GameManager gm)   //Arxikopoiei tis metavlites tou paixti stin arxi tou paixnidiou
    {
        this.playerNo = playerNo;
        this.gm = gm;
        //print("player Numbuer: " + this.playerNo);
        properties = new List<Property>();
        currentPos = 0;
        currentSquare = start;
        RoundsInJail = 0;
        playerInGame = true;
        balance = 3000;
        OnMove = false;
        m_player = this.GetComponent<PlayerMovement>();
        t_manager.setupPlayer(this.playerNo);
        
    }

    public int Move(square target)  //Kinei ton paixti, kaleitou mono apo ton TableManager oxi apo moni tis
    {

        /*currentSquare = currentSquare.nextSq;
        m_player.target = currentSquare.path_p1;
        
        currentPos++;
        //currentPos = currentSquare.sqid;*/
        if (target.sqid < currentSquare.sqid && !inJail)
        {
            StartCoroutine(gm.DisplayMessageForSeconds("You pass through the start, You take 200 euros"));
            addMoney(200);
        }
        this.m_player.target = target;
        currentSquare = target;
        currentPos = target.sqid;
        return 0;
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void setTableManager(TableManager tm)
    {
        this.t_manager = tm;
    }

    public void BuyProperty(Property Prop)  //Entoli agoras idioktisias
    {
        Prop.SetOwner(this);
        properties.Add(Prop);
        
        Pay(Prop.price);
    }

    public void PlayerLost()    //Ekteleitai an o paixtis xasei
    {
        playerInGame = false;
        foreach (Property p in properties) p.SetOwner(null);
    }
}
