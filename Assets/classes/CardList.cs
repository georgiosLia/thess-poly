using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Anaparista tin klassi pou dimiourgie tin vai dendomenwn twn kartwn tou paixnidiou
//Periexei tis idioktisies kai tis special cards - entoles apofaseis forous fylaki ktl
public class CardList : ScriptableObject
{
    public List<Property> cardList;
    public List<SpecialCard> specialCardList;


    private void Awake()
    {
        Sprite[] mySprites = Resources.LoadAll<Sprite>("Resources/texture/kartes_idioktisiwn/");
        
        cardList = createCards2();
        specialCardList = createSpecialCards();

    }

    

    /*private List<card> createCards()
    {

        List<card> allcards = new List<card>();
        card brown1 = new Property("01.png", 60, 2, 4, 1, 50, 10, 30, 90, 160, 250, 50);
        allcards.Add(brown1);
        card brown2 = new Property("02.png", 60, 4, 8, 2, 50, 20, 60, 180, 320, 450, 50);
        allcards.Add(brown2);
        card blue1 = new Property("03.png", 100, 6, 12, 3, 50, 30, 90, 270, 400, 550, 50);
        allcards.Add(blue1);
        card blue2 = new Property("04.png", 100, 6, 12, 4, 50, 30, 90, 270, 400, 550, 50);
        allcards.Add(blue2);
        card blue3 = new Property("05.png", 120, 8, 16, 5, 50, 40, 100, 300, 450, 600, 50);
        allcards.Add(blue3);
        card pink1 = new Property("06.png", 140, 10, 20, 6, 100, 50, 150, 450, 625, 700, 100);
        allcards.Add(pink1);
        card pink2 = new Property("07.png", 140, 10, 20, 7, 100, 50, 150, 450, 625, 700, 100);
        allcards.Add(pink2);
        card pink3 = new Property("08.png", 160, 12, 24, 8, 100, 60, 180, 500, 700, 900, 100);
        allcards.Add(pink3);
        card orange1 = new Property("09.png", 180, 14, 28, 9, 100, 70, 200, 550, 750, 950, 100);
        allcards.Add(orange1);
        card orange2 = new Property("10.png", 180, 14, 28, 10, 100, 70, 200, 550, 750, 950, 100);
        allcards.Add(orange2);
        card orange3 = new Property("11.png", 200, 16, 32, 11, 100, 80, 220, 600, 800, 1000, 100);
        allcards.Add(orange3);
        card red1 = new Property("12.png", 220, 18, 36, 12, 150, 90, 250, 700, 875, 1050, 150);
        allcards.Add(red1);
        card red2 = new Property("13.png", 220, 18, 36, 13, 150, 90, 250, 700, 875, 1050, 150);
        allcards.Add(red2);
        card red3 = new Property("14.png", 240, 20, 40, 14, 150, 100, 300, 750, 925, 1100, 150);
        allcards.Add(red3);
        card yellow1 = new Property("15.png", 260, 22, 44, 15, 150, 110, 330, 800, 975, 1150, 150);
        allcards.Add(yellow1);
        card yellow2 = new Property("16.png", 260, 22, 44, 16, 150, 110, 330, 800, 975, 1150, 150);
        allcards.Add(yellow2);
        card yellow3 = new Property("17.png", 280, 24, 48, 17, 150, 120, 360, 850, 1025, 1200, 150);
        allcards.Add(yellow3);
        card green1 = new Property("18.png", 300, 26, 52, 18, 200, 130, 390, 900, 1100, 1275, 200);
        allcards.Add(green1);
        card green2 = new Property("19.png", 300, 26, 52, 19, 200, 130, 390, 900, 1100, 1275, 200);
        allcards.Add(green2);
        card green3 = new Property("20.png", 320, 28, 56, 20, 200, 150, 450, 1000, 1200, 1400, 200);
        allcards.Add(green3);
        card dblue1 = new Property("21.png", 350, 35, 70, 21, 200, 175, 500, 1100, 1300, 1500, 200);
        allcards.Add(dblue1);
        card dblue2 = new Property("22.png", 400, 50, 100, 22, 200, 200, 600, 1400, 1700, 2000, 200);
        allcards.Add(dblue2);
        return allcards;
    }*/
    private List<Property> createCards2()
    {

        List<Property> allcards = new List<Property>();
        Property brown1 = new Property("01.png", 60, 2, 4, 1, 50, 10, 30, 90, 160, 250, 50, 1, Resources.Load<Sprite>("texture/kartes_idioktisiwn/02"));
        Property brown2 = new Property("02.png", 60, 4, 8, 2, 50, 20, 60, 180, 320, 450, 50, 3, Resources.Load<Sprite>("texture/kartes_idioktisiwn/01"));
        
        Property blue1 = new Property("03.png", 100, 6, 12, 3, 50, 30, 90, 270, 400, 550, 50, 6, Resources.Load<Sprite>("texture/kartes_idioktisiwn/03"));
        
        Property blue2 = new Property("04.png", 100, 6, 12, 4, 50, 30, 90, 270, 400, 550, 50, 8, Resources.Load<Sprite>("texture/kartes_idioktisiwn/04"));
        
        Property blue3 = new Property("05.png", 120, 8, 16, 5, 50, 40, 100, 300, 450, 600, 50, 9, Resources.Load<Sprite>("texture/kartes_idioktisiwn/05"));
        
        Property pink1 = new Property("06.png", 140, 10, 20, 6, 100, 50, 150, 450, 625, 700, 100, 11, Resources.Load<Sprite>("texture/kartes_idioktisiwn/06"));
        
        Property pink2 = new Property("07.png", 140, 10, 20, 7, 100, 50, 150, 450, 625, 700, 100, 13, Resources.Load<Sprite>("texture/kartes_idioktisiwn/07"));
        
        Property pink3 = new Property("08.png", 160, 12, 24, 8, 100, 60, 180, 500, 700, 900, 100, 14, Resources.Load<Sprite>("texture/kartes_idioktisiwn/08"));
        
        Property orange1 = new Property("09.png", 180, 14, 28, 9, 100, 70, 200, 550, 750, 950, 100, 16, Resources.Load<Sprite>("texture/kartes_idioktisiwn/09"));
        
        Property orange2 = new Property("10.png", 180, 14, 28, 10, 100, 70, 200, 550, 750, 950, 100, 18, Resources.Load<Sprite>("texture/kartes_idioktisiwn/10"));
        
        Property orange3 = new Property("11.png", 200, 16, 32, 11, 100, 80, 220, 600, 800, 1000, 100, 19, Resources.Load<Sprite>("texture/kartes_idioktisiwn/11"));
        
        Property red1 = new Property("12.png", 220, 18, 36, 12, 150, 90, 250, 700, 875, 1050, 150, 21, Resources.Load<Sprite>("texture/kartes_idioktisiwn/12"));
        
        Property red2 = new Property("13.png", 220, 18, 36, 13, 150, 90, 250, 700, 875, 1050, 150, 23, Resources.Load<Sprite>("texture/kartes_idioktisiwn/13"));
        
        Property red3 = new Property("14.png", 240, 20, 40, 14, 150, 100, 300, 750, 925, 1100, 150, 24, Resources.Load<Sprite>("texture/kartes_idioktisiwn/14"));
        
        Property yellow1 = new Property("15.png", 260, 22, 44, 15, 150, 110, 330, 800, 975, 1150, 150, 26, Resources.Load<Sprite>("texture/kartes_idioktisiwn/15"));
        
        Property yellow2 = new Property("16.png", 260, 22, 44, 16, 150, 110, 330, 800, 975, 1150, 150, 27, Resources.Load<Sprite>("texture/kartes_idioktisiwn/16"));
        
        Property yellow3 = new Property("17.png", 280, 24, 48, 17, 150, 120, 360, 850, 1025, 1200, 150, 29, Resources.Load<Sprite>("texture/kartes_idioktisiwn/17"));
        
        Property green1 = new Property("18.png", 300, 26, 52, 18, 200, 130, 390, 900, 1100, 1275, 200, 31, Resources.Load<Sprite>("texture/kartes_idioktisiwn/18"));
        
        Property green2 = new Property("19.png", 300, 26, 52, 19, 200, 130, 390, 900, 1100, 1275, 200, 32, Resources.Load<Sprite>("texture/kartes_idioktisiwn/19"));
        
        Property green3 = new Property("20.png", 320, 28, 56, 20, 200, 150, 450, 1000, 1200, 1400, 200, 34, Resources.Load<Sprite>("texture/kartes_idioktisiwn/20"));
        
        Property dblue1 = new Property("21.png", 350, 35, 70, 21, 200, 175, 500, 1100, 1300, 1500, 200, 37, Resources.Load<Sprite>("texture/kartes_idioktisiwn/21"));

        Property dblue2 = new Property("22.png", 400, 50, 100, 22, 200, 200, 600, 1400, 1700, 2000, 200, 39, Resources.Load<Sprite>("texture/kartes_idioktisiwn/22"));
        /*
        //brown
        brown1.SameColour.Add(brown2);
        brown2.SameColour.Add(brown1);

        //blue
        blue1.SameColour.Add(blue2);
        blue1.SameColour.Add(blue3);

        blue2.SameColour.Add(blue1);
        blue2.SameColour.Add(blue3);

        blue3.SameColour.Add(blue1);
        blue3.SameColour.Add(blue2);

        //pink
        pink1.SameColour.Add(pink2);
        pink1.SameColour.Add(pink3);

        pink2.SameColour.Add(pink1);
        pink2.SameColour.Add(pink3);

        pink3.SameColour.Add(pink1);
        pink3.SameColour.Add(pink2);

        //orange
        orange1.SameColour.Add(orange2);
        orange1.SameColour.Add(orange3);

        orange2.SameColour.Add(orange1);
        orange2.SameColour.Add(orange3);

        orange3.SameColour.Add(orange1);
        orange3.SameColour.Add(orange2);

        //red
        red1.SameColour.Add(red2);
        red1.SameColour.Add(red3);

        red2.SameColour.Add(red1);
        red2.SameColour.Add(red3);

        red3.SameColour.Add(red1);
        red3.SameColour.Add(red2);

        //yellow
        yellow1.SameColour.Add(yellow2);
        yellow1.SameColour.Add(yellow3);

        yellow2.SameColour.Add(yellow1);
        yellow2.SameColour.Add(yellow3);

        yellow3.SameColour.Add(yellow1);
        yellow3.SameColour.Add(yellow2);

        //green
        green1.SameColour.Add(green2);
        green1.SameColour.Add(green3);

        green2.SameColour.Add(green1);
        green2.SameColour.Add(green3);

        green3.SameColour.Add(green1);
        green3.SameColour.Add(green2);

        //dblue
        dblue1.SameColour.Add(dblue2);

        dblue2.SameColour.Add(dblue1);
        */

        brown1.SameC.Add(1);
        brown2.SameC.Add(0);

        allcards.Add(brown1);
        allcards.Add(brown2);
        allcards.Add(blue1);
        allcards.Add(blue2);
        allcards.Add(blue3);
        allcards.Add(pink1);
        allcards.Add(pink2);
        allcards.Add(pink3);
        allcards.Add(orange1);
        allcards.Add(orange2);
        allcards.Add(orange3);
        allcards.Add(red1);
        allcards.Add(red2);
        allcards.Add(red3);
        allcards.Add(yellow1);
        allcards.Add(yellow2);
        allcards.Add(yellow3);
        allcards.Add(green1);
        allcards.Add(green2);
        allcards.Add(green3);
        allcards.Add(dblue1);
        allcards.Add(dblue2);

        return allcards;
    }

    private List<SpecialCard> createSpecialCards()
    {
        List<SpecialCard> list = new List<SpecialCard>();
       

        list.Add(new SpecialCard("apofasi1", 23, -1, SpecialCard.APOFASI, new gotoblue2()));
        list.Add(new SpecialCard("apofasi2", 24, -1, SpecialCard.APOFASI, new add50()));
        list.Add(new SpecialCard("Entoli1", 25, -2, SpecialCard.ENTOLI, new goback3()));
        list.Add(new SpecialCard("Entoli2", 26, -2, SpecialCard.ENTOLI, new Pay15()));
        list.Add(new SpecialCard("gotoJail_s", 27, 30, "", new gotoJail()));
        list.Add(new SpecialCard("Entoli_s1", 28, 2, "", new Entoli()));
        list.Add(new SpecialCard("Entoli_s2", 29, 17, "", new Entoli()));
        list.Add(new SpecialCard("Entoli_s3", 30, 33, "", new Entoli()));
        list.Add(new SpecialCard("Apofasi_s1", 31, 7, "", new Apofasi()));
        list.Add(new SpecialCard("Apofasi_s2", 32, 22, "", new Apofasi()));
        list.Add(new SpecialCard("Apofasi_s3", 33, 36, "", new Apofasi()));
        list.Add(new SpecialCard("Tax1_s", 34, 4, "", new Tax1()));
        list.Add(new SpecialCard("Tax2_s", 35, 38, "", new Tax2()));

     

        return list; 
    }

}
