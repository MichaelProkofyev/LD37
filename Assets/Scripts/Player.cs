using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private KeyCode[] keyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

	public PeopleController people;
    public TVController tv;

	public bool stopped;


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

		if(!stopped) {


	        if(Input.GetKeyDown(KeyCode.Space))
	        {
	            //tv.BuySelected();
				//people.StartCoroutine(people.GoToExit());
	        }

		    if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
	        {
	            tv.ChangeProduct();
	        }
	        else if(Input.anyKeyDown)
	        {

	            //Check for numbers

	            for (int i = 0; i < keyCodes.Length; i++)
	            {
	                if (Input.GetKeyDown(keyCodes[i]))
	                {
	                    int numberPressed = i + 1;
	                    //Debug.Log(numberPressed.ToString()[0]);
	                    tv.EnterLetter(numberPressed.ToString()[0]);
	                    return;
	                }
	            }

	            //check for letters
	                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
	            {
	                if (Input.GetKey(vKey))
	                {
	                //    print(vKey.ToString().ToLowerInvariant()[0]);
	                    tv.EnterLetter(vKey.ToString().ToLowerInvariant()[0]);
	                    return;  
	                }
	            }
			}
        }

	}
}
