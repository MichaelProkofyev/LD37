using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UIState
{
    MENU,
    STARTED,
    ENDED
} 

public class UIController : MonoBehaviour {

    public UIState State
    {
        get { return state; }
        set
        {
            switch (value)
            {
                case UIState.MENU:
                    break;
                case UIState.STARTED:
                    break;
                case UIState.ENDED:
                    break;
                default:
                    break;
            }
            state = value;
        }
    }

    public Slider happinessBar;
    public ShakeController shakeBarController;
    public Text cashAmountText;

    private UIState state;

    
    public void SetHappinessTo(float newAmount)
    {
        happinessBar.value = newAmount;
    }

    public void ShakeCharm ()
    {
        shakeBarController.Shake();
    }

    public void SetCashAmountTo(float newAmount)
    {
        cashAmountText.text = newAmount + "$";
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
