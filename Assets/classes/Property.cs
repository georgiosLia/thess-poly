using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//Anaparista kathe idioktisia mesa sto paixnidi kai klironwmei thn Card
public class Property : card {
    [SerializeField]
    public int price; //Timi
    [SerializeField]
    public int rent;                    //<-- Oi times pou aforoun enoikia kai spitia gia kathe ioktisia
    public int fullrent;
    public int homesbuilt;
    public int hotelsbuilt;
    public int homeprice;
    public int hotelprice;
    public int rentwith1home;
    public int rentwith2homes;
    public int rentwith3homes;
    public int rentwith4homes;
    public int rentwith1hotel;
    public bool allcolorsbought;        //An exoun agwrastei kai ta ypoloipa tou idiou xrwmatos
    public bool CanBuilt;               //An mporeis na xtiseis, se periptwseis stathmwn kai ypiresiwn pou ypologizetai alliws to poso plirwmis
    public player owner;                //Idioktitis paiktis
    public PropertyPayScript payScript; //Xrisimipoieitai gia tous stathmous kai tis ypiresies opou o tropos polirwmis ypologizetai alliws
    public List<Property> SameColour;   
    public List<int> SameC;             //Oi idioktisies me to idio xrwma, o arithmos tous, xrisimopoieitia gia ton elegxo idiou xrwmatos
    public bool isMortage;              //An einai ypothikevmeni
 
    public Property(string picture, int price, int rent, int fullrent, int id, int homeprice, int rentwith1home, int rentwith2homes,
        int rentwith3homes, int rentwith4homes, int rentwith1hotel, int hotelprice, int sqid, Sprite sprite) : base(picture,id,sqid,sprite)
    {
        this.owner = null;
        this.picture = picture;
        this.price = price;
        this.rent = rent;
        this.fullrent = fullrent;
        this.id = id;
        homesbuilt = 0;
        hotelsbuilt = 0;
        this.homeprice = homeprice;
        this.hotelprice = hotelprice;
        this.rentwith1home = rentwith1home;
        this.rentwith2homes = rentwith2homes;
        this.rentwith3homes = rentwith3homes;
        this.rentwith4homes = rentwith4homes;
        this.rentwith1hotel = rentwith1hotel;
        this.isMortage = false;
        allcolorsbought = false;
        SameColour = new List<Property>();
        SameC = new List<int>();
    }
    
    public void setMortage()   //Orismos ypothikis
    {
        isMortage = true;
        owner.balance += price * (2 / 3);
    }

    //Elazei ton idioktiti se periptwsh agwras kai elegxei an exoun agwrastei ta ypoloipa xromata apo ton idio idioktiti
    public void SetOwner(player Pl) //Allagi idioktiti
    {
        this.owner = Pl;
        if (payScript != null)
        {
            payScript.Owner = Pl;
        }
        //this.allcolorsbought = AllColoursBought();
        //Elegxw an exoun agorastei ola ta xromata kapws :/
    }

    public int GetPayAmount(TableManager tm)    //Elegxei to poso plirwmis analoga me tis idioktisies tou paixti kai ta spitia h ksenadoxeia pou exei ktisei
                                                
    {
        if (CanBuilt == true && payScript == null)
        {
            if (hotelsbuilt == 0)
            {
                if (homesbuilt == 0) return rent;
                else if (homesbuilt == 1) return rentwith1home;
                else if (homesbuilt == 2) return rentwith2homes;
                else if (homesbuilt == 3) return rentwith3homes;
                else if (homesbuilt == 4) return rentwith4homes;
            }
            else if (hotelsbuilt == 1)
            {
                return rentwith1hotel;
            }
        }
        else
        {
            return payScript.GetPayAmount(tm.squares); //An prokeitai gia stathmo h ypiresia ypologizetai me idietairo tropo to poso plirwmis mesw
                                                       //kapoiou prokatorismenou payScript
        }
        // payScript.GetPrice;
        
        
        return 0;
    }

    public bool AllColoursBought(GameManager gm, player pl = null)  //elegxei an exoun agwrastei ola ta xrwmara tis idioktisias apo ton idioktiti tis
    {
        player aPlayer = pl;
        //if (pl == null) aPlayer = this.owner;
        //else aPlayer = pl;

        foreach (int prop in SameC)
        {
            if (gm.properties[prop].owner != aPlayer) return false;
        }
        return true;
    }

    public int Build(bool BuiltHotel = false)   //Sinartisi pou xtizei spitia kai ksenadoxeia, periexei kai tous katallilous elegxous, einai to messaio
                                                //stadio elegxou metaksi tou UImanager kai tou square pou emfanizei to spiti h to ksenadoxeio
    {
        if(CanBuilt)
        {
            if(homesbuilt < 4)
            {
                CardSquare.Build();
                homesbuilt++;
                return 1;
            }
            else if(hotelsbuilt < 1 && BuiltHotel)
            {
                CardSquare.Build();
                hotelsbuilt++;
                return 1;
            }
        }
        return -1;
    }
}
