using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHeadScript : MonoBehaviour {

    Image moneyImage;
    Animator moneyAnimator;

    public void MoneyImageDisable()
    {
        moneyImage.enabled = false;
    }

    public void MoneyImagePlayAnim()
    {
        moneyAnimator.SetTrigger("moneyEarned");
        moneyImage.enabled = true;

    }

    // Use this for initialization
    void Start () {
        moneyAnimator = GetComponent<Animator>();
        moneyImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
