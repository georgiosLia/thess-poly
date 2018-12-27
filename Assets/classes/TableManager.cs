using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
//O TableManager einai to kentro elegxou tou tamplo, periexei theseis, tetragwna, zaria kai methodous kinisis twn paixtwn
public class TableManager
{
	private GameManager gameManager;//O kentrikos gameManager
	private const int table_sq_size = 39;//Plithos square tou tamplo
    public GameObject[] path_points;//Ta simeia tou kyriou monopatiou
    public GameObject[] squares;    //H lista me ta gameobject twn tetragwnwn tou tamplo

    public GameObject dice1;    //Zari1
    public GameObject dice2;    //Zari2
    public GameObject diceButton;//to koumpi pou rixnei ta zaria
    public Button diceB;
    private bool btnPressed;    //An patithei to koumpi

    private List<int> player_posisitions;//h Thesi kathe paikth

    public static int JAIL = 10;    //Stathera simeiou pou vrisketai h flaki
    public static int START = 0;    //Stathera simeiou pou vrisketai h enarksi

    public GameObject Camera;       //To gameobject tis cameras

    //Dicce Camera Transform
    private Vector3 DiceCameraPos = new Vector3(1.27f,6.2f,4.1f);           //H thesi kai h peristrofi gia thn provoli twn zariwn sthn statheri camera
    private Vector3 DiceCameraRot = new Vector3(117.64f, -20.8f, -180);


    public TableManager ()
	{
		
	}

    public void setUp(GameManager gm)   //Arxikopoihsh metavlitwn TableManager
    {
        this.gameManager = gm;
        player_posisitions = new List<int>(gm.num_players);
        diceB = diceButton.GetComponent<Button>();
        diceB.onClick.AddListener(DiceButton);
    }

    private void DiceButton()
    {
        btnPressed = true;
    }

    public int MovePlayer(player plyer, int steps) //Xrismopoieitai gia na kinithei o paixtis enan arithmo vimatwn simfwna me
                                                   //Ton pinaka square. Ypologizei thn diafora - steps kai kalei ton MovePlayerTo
    {
        int currentPlayerPos = plyer.currentPos; //player_posisitions[plyer.playerNo];

        int targetPos = (currentPlayerPos + steps) % (table_sq_size + 1); //Otan teleiwsei to tamplo pane stin arxi pali

        //MonoBehaviour.print("curr: " + currentPlayerPos + ", target: " + targetPos);

        MovePlayerTo(plyer, targetPos);



        return -1;
    }

    public int MovePlayerTo(player plyer, int target) //Xrismimopoieitai gia na kinisei ton paixnti se siggekrimeni thesi sto tamplo, 
    {

        /*while (plyer.currentPos <= target)
        {
            plyer.Step();
        }*/
        plyer.Move(squares[target].GetComponent<square>());

        return -1;
    }

    public Transform setupPlayer(int plno) //Arxikopoiei tis metavlites gia kathe paixti
    {
        //MonoBehaviour.print(plno);
        player_posisitions.Insert(plno, 0);
        MonoBehaviour.print(path_points[0].name);
        return path_points[0].transform;
    }

    public IEnumerator ThrowDice () //Cooroutine gia tin ripsi twn zariwn
    {
        //Emfanizei to koumpi kai allazei thn thesi tis cameras na koitaei ta zaria
        Camera.GetComponent<CameraControler>().enabled = false;
        Camera.GetComponent<StaticCamera>().enabled = true;
        btnPressed = false;
        diceButton.SetActive(true);
        MonoBehaviour.print("Thrown dice now");
        while(btnPressed == false)
        {
            yield return null;
        }
        diceButton.SetActive(false);
        btnPressed = false;

        while(!dice1.GetComponent<Rigidbody>().IsSleeping() && !dice2.GetComponent<Rigidbody>().IsSleeping()) //Perimenei na stamatisoun na kinountai ta zaria
        {
            yield return null;
        }
        yield return gameManager.DisplayMessageForSeconds("Dice total: " + (PlayerPrefs.GetInt("d1") + PlayerPrefs.GetInt("d2")));
        Camera.GetComponent<CameraControler>().enabled = true;
        Camera.GetComponent<StaticCamera>().enabled = false;
        yield return new WaitForSeconds(2f);
    }
}


