using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
    STARTED,
    ENDED
}

public class GameController : MonoBehaviour {

    public PeopleController people;

    public GameState State
    {
        get { return state; }
        set
        {
            switch (value)
            {
                case GameState.MENU:
                    break;
                case GameState.STARTED:
                    Happiness = 0;
                    Cash = 100;
                    break;
                case GameState.ENDED:
                    break;
                default:
                    break;
            }

            state = value;
        }
    }

    public float Happiness
    {
        get { return happiness; }
        set
        {
            if(value > happiness)
            {
                //Try to invite someone
                people.HappinessIncreased(happiness, value);
                
            }else
            {
                //Check if someone needs to be kicked out
                people.HappinessDecreased(happiness, value);
            }
            
            happiness = value;
            ui.SetHappinessTo(happiness);

        }
    }

    public float Cash
    {
        get { return cash; }
        set
        {
            cash = value;
            ui.SetCashAmountTo(cash);
        }
    }

    private float cash;
    private float happiness;
    private GameState state;
    private UIController ui;

	// Use this for initialization
	void Start () {
        ui = GetComponent<UIController>();
        State = GameState.STARTED;
        
	}
	
	// Update is called once per frame
	void Update () {
        switch (State)
        {
            case GameState.MENU:
                break;
            case GameState.STARTED:
                break;
            case GameState.ENDED:
                break;
            default:
                break;
        }
    }
}
