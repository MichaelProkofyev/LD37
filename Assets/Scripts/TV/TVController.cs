using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TVState
{
    MENU,
    STARTED,
    ENDED
}


public class TVController : MonoBehaviour {


    //TV UI
    public Text objTitle;
    public ScaleByTypingController typeHintText;
    public PriceTVLabel priceLabel;
    public Animator attractionTextAnim;

    //REGULAR UI
    public HandsController hands;
    public ShakeController moneyUI;

    public GameObject vacuumCleanerPrefab, radioPrefab, juiceMakerPrefab, knivesPrefab, toasterPrefab, panPrefab, jewelryPrefab;
    public GameController gameController;
    public ObjectSpaceController objectSpaceController;
    public string currObjCommand;


    List<TVObject> objects = new List<TVObject>();

    private string[] magicNumbers = new string[9] { "111", "222", "333", "444", "555", "666", "777", "888", "999" };

    int selectedObjIdx = 0;
    int currentObjPrice;


    public TVState State
    {
        get { return state; }
        set
        {
            switch (value)
            {
                case TVState.MENU:
                    break;
                case TVState.STARTED:
                    ChangeProduct();
                    break;
                case TVState.ENDED:
                    break;
                default:
                    break;
            }
            state = value;
        }
    }

    private TVState state;


    private int currCorrectLetters = 0;
    public void EnterLetter(char newChar) {

        if(gameController.Cash < currentObjPrice)
        {
            //NEED MORE MONEY FOR THAT
            //   priceLabel.Shake();
            moneyUI.Shake();
            return;
        }

        char currLetterToEnter = currObjCommand[currCorrectLetters];
        
        if (currLetterToEnter == newChar)
        {
            currCorrectLetters++;
            if(currCorrectLetters == 3) currCorrectLetters++; //skip the minus
            typeHintText.AddScale();
            hands.TypeSymbol();
            typeHintText.SetText("<color=#F24C0BFF>\"" + currObjCommand.Insert(currCorrectLetters, "</color>") + "\"");
        }


        if(currCorrectLetters == currObjCommand.Length)
        {
            BuySelected();
        }
    }

    public void BuySelected() {
        TVObject selectedObj = objects[selectedObjIdx];
        gameController.Happiness += selectedObj.happinessAmount;
        gameController.Cash -= currentObjPrice;
        attractionTextAnim.Play("GainedAttraction");
        attractionTextAnim.GetComponent<Text>().text = "Charm" + new string('+',selectedObj.happinessAmount / 5);
        GameObject objClone = GameObject.Instantiate(selectedObj.physicalObject, objectSpaceController.RandomSpawnPoint(), Quaternion.identity);
        objClone.transform.parent = objectSpaceController.transform;
        ChangeProduct();
    }

    public void ChangeProduct()
    {
        selectedObjIdx = Random.Range(0, objects.Count);
        currentObjPrice = objects[selectedObjIdx].basePrice + Random.Range((int)(-objects[selectedObjIdx].basePrice * 0.3f), 0);
        objTitle.text = objects[selectedObjIdx].fullName;
        priceLabel.SetPrice(currentObjPrice);
        currObjCommand = magicNumbers[Random.Range(0, magicNumbers.Length)] + "-" + objects[selectedObjIdx].nickname.ToLowerInvariant();
        typeHintText.SetText("\"" + currObjCommand+ "\"");
        currCorrectLetters = 0;
        hands.TypeSymbol();
    }

    void Start () {
        TVObject vacuumCleaner = new TVObject();
        vacuumCleaner.physicalObject = vacuumCleanerPrefab;
        vacuumCleaner.fullName = "Vacuum Cleaner";
        vacuumCleaner.nickname = "roomba";
        vacuumCleaner.basePrice = 60;
        vacuumCleaner.happinessAmount = 20;
        objects.Add(vacuumCleaner);

        TVObject radio = new TVObject();
        radio.physicalObject = radioPrefab;
        radio.fullName = "Radio";
        radio.nickname = "retro";
        radio.basePrice = 45;
        radio.happinessAmount = 15;
        objects.Add(radio);

        TVObject juiceMaker = new TVObject();
        juiceMaker.physicalObject = juiceMakerPrefab;
        juiceMaker.fullName = "JuiceMaker";
        juiceMaker.nickname = "health";
        juiceMaker.basePrice = 60;
        juiceMaker.happinessAmount = 20;
        objects.Add(juiceMaker);

        TVObject knives = new TVObject();
        knives.physicalObject = knivesPrefab;
        knives.fullName = "Set Of Knives";
        knives.nickname = "ninja";
        knives.basePrice = 15;
        knives.happinessAmount = 5;
        objects.Add(knives);

        TVObject toaster = new TVObject();
        toaster.physicalObject = toasterPrefab;
        toaster.fullName = "Toaster";
        toaster.nickname = "coals";
        toaster.basePrice = 45;
        toaster.happinessAmount = 15;
        objects.Add(toaster);

        TVObject pan = new TVObject();
        pan.physicalObject = panPrefab;
        pan.fullName = "Pan";
        pan.nickname = "bubbly";
        pan.basePrice = 30;
        pan.happinessAmount = 10;
        objects.Add(pan);

        
        TVObject jewelry = new TVObject();
        jewelry.physicalObject = jewelryPrefab;
        jewelry.fullName = "Jewelry";
        jewelry.nickname = "rich";
        jewelry.basePrice = 105;
        jewelry.happinessAmount = 35;
        objects.Add(jewelry);

        State = TVState.STARTED;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

class TVObject
{
    public string fullName;
    public string nickname;
    public int basePrice;
    public int happinessAmount;
    public GameObject physicalObject;
}
