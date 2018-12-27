using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class UIManager : MonoBehaviour {

    //O UIManager elegxei ta parathira kai tis leitourgeies tous kathe fora gia enan paixti kai idioktisia antistoixa
    


    GameManager gm;             //O kyrios GameManager tou paixnidiou
    player currentPlayer;       //O paixtis kathe fora
    bool ButtonPressed = false; //Metavliti elegxou
    public GameObject MainCanvas;
    card currCard;              //H karta kathe fora
    bool LeaveButtonPressed = false;    //Metavliti elegxou gia eksodo apo to loop kathe fora

    public void Start()
    {
        
        this.MainCanvas = this.gameObject;
    }
	
    public void SetUp(GameManager gm)
    {
        this.gm = gm;
    }

    public IEnumerator BuyPropertyWindow(Property prop, player pl)  //Elegxos parathirou agoras idioktisias, elegxei ola ta grafika stoixeia tou
    {
        currCard = prop;
        currentPlayer = pl;
        ButtonPressed = false;
        GameObject ui;
        ui = MainCanvas.transform.Find("bor").gameObject;
        
        ui.SetActive(true);
        Image img = ui.transform.Find("Image").gameObject.GetComponent<Image>();
        img.sprite = currCard.icon; //Resources.Load<Sprite>("texture/kartes_idioktisiwn/02");
        
        while (ButtonPressed == false) yield return null;
        ui.SetActive(false);
    }

    public IEnumerator BuyHouseHotelWindow(Property prop, player pl) //Elegxei ta grafika stoixeia tou parathirou agoras spitiwn kai ksenadoxeiwn
    {
        if (prop.CanBuilt == false) yield break;    //An den ginetai na xtiseis se authn thn idioktisia (periptwsh stathmwn kai yphresiwn) tote vgainei
                                                    //apo tin epanalipsi xwris na ginei kamia energeia
        GameObject ui;                              
        currCard = prop;
        currentPlayer = pl;
        ui = MainCanvas.transform.Find("BuyHouseHotels").gameObject;
        ui.SetActive(true);
        LeaveButtonPressed = false;
        ButtonPressed = false;
        
        while (LeaveButtonPressed == false)
        {
            ButtonPressed = false;
            GameObject TextFieldHouse = ui.transform.Find("NumOfHomesText").gameObject;
            TextFieldHouse.SetActive(true);
            ui.transform.Find("NumOfHomesText").GetComponent<Text>().text = "" + prop.homesbuilt;

            GameObject TextFieldHotel = ui.transform.Find("NumOfHotelsText").gameObject;
            TextFieldHotel.SetActive(true);
            ui.transform.Find("NumOfHotelsText").GetComponent<Text>().text = "" + prop.hotelsbuilt;

            

            while (ButtonPressed == false) yield return null;
        }

        ui.SetActive(false);
        
    }

    public IEnumerator BuyHomeBtn() //Energeies pou ektelountai otan o paixtis patisei to koumpi Buy
    {
        if(currentPlayer.balance > ((Property)currCard).homeprice)
        {
            if(((Property)currCard).Build() > 0)
            {
                //((Property)currCard).homesbuilt++;
                currentPlayer.Pay(((Property)currCard).homeprice);
                yield return gm.DisplayMessageForSeconds("You have bought a house");
            }
            else
            {
                yield return gm.DisplayMessageForSeconds("You already have 4 houses");
            }
            
        }
        else
        {
            yield return gm.DisplayMessageForSeconds("You dont have enough money");
        }
        ButtonPressed = true;
    }

    public void ButtonPress(int id) //Auth h sinartisi epikoinwnei me ta koumpia kai tis leiourgeies tous
                                    //epidei einai adynato na ksekinisoun cooroutine mesw energeiwn tou koumpiou
                                    //kathe action orizetai apo ton arithmo id pou eidagetai sto koumpi sto unity
                                    //kata tin ektelesi tin ButtonPress
    {
        switch (id)
        {
            case 1:
                StartCoroutine(BuyBtn());
                break;
            case 2:
                StartCoroutine(BuyHomeBtn());
                break;
            case 3:
                StartCoroutine(BuyHotelBtn());
                break;
            case 4:
                StartCoroutine(JailPayButton());
                break;
            case -1:
                StartCoroutine(LeaveButton());
                break;
            default:
                StartCoroutine(LeaveButton());
                break;
        }
    } 

    public IEnumerator BuyHotelBtn()
    {
        if (currentPlayer.balance > ((Property)currCard).hotelprice)
        {
            if (((Property)currCard).Build(true) > 0)
            {
                ((Property)currCard).hotelsbuilt++;
                currentPlayer.Pay(((Property)currCard).hotelprice);
                yield return gm.DisplayMessageForSeconds("You have bought a hotel");
            }
            else
            {
                yield return gm.DisplayMessageForSeconds("You already have a hotel");
            }

        }
        else
        {
            yield return gm.DisplayMessageForSeconds("You dont have enough money dude");
        }

        ButtonPressed = true;
    }

    public IEnumerator BuyBtn()
    {
        if (currentPlayer.balance > ((Property)currCard).price)
        {
            currentPlayer.BuyProperty((Property)currCard);
            yield return gm.DisplayMessageForSeconds("Player " + (currentPlayer.playerNo + 1) + " bought property " + currCard.id);
            ButtonPressed = true;
        }
        else
        {
            yield return gm.DisplayMessageForSeconds("You dont have enough money");
        }
    }

    private IEnumerator LeaveButton()
    {
        //Diasplay a message propably
        yield return null;
        ButtonPressed = true;
        LeaveButtonPressed = true;
    }

    public IEnumerator JailPayWindow(player pl)
    {
        GameObject ui;
        //currCard = prop;
        currentPlayer = pl;
        ui = MainCanvas.transform.Find("PayJailPanel").gameObject;
        ui.SetActive(true);
        LeaveButtonPressed = false;
        ButtonPressed = false;
        while (!ButtonPressed || !LeaveButtonPressed) yield return null;
        ui.SetActive(false);
    }

    private IEnumerator JailPayButton()
    {
        yield return gm.DisplayMessageForSeconds("You payed 50 bucks you are free ;)", 2f);
        currentPlayer.Pay(50);
        currentPlayer.inJail = false;
        currentPlayer.RoundsInJail = 0;
        ButtonPressed = true;
        LeaveButtonPressed = true;
    }
}
