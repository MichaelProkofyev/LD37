using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HumanState
{
    IDLE,
    LINGERING,
    WALKING_OUT
}
public class Human : MonoBehaviour {

    static string[] entryPhrases = new string[7] { "BETTER THAN MY CRIB!", "WTF, RAIN?", "THAT'S SO 80S!", "COOL SHIT!", "NEW THINGS!", "DOPE.", "DOPE.", };
    static string[] exitPhrases = new string[7] { "NOTHING NEW HERE!", "BORED!", "I'VE SEEN THAT!", "BUY SOMETHING ALREADY!", "NOT CHARMED ANYMORE!", "BORED!", "BORED!", };



    public HumanState State
    {
        get { return state; }
        set
        {
            switch (value)
            {
                case HumanState.LINGERING:
                    animationController.SetBool("walking", true);
                    currTargetPoint = RandPointInLingerZone();
                    walkSpeed = 1f;
                    break;
                case HumanState.IDLE:
                    if(!firstIdleHappened)
                    {
                        firstIdleHappened = true;
                        StartCoroutine(SayEntryPhrase());
                    }
                    animationController.SetBool("walking", false);
                    break;
                case HumanState.WALKING_OUT:
                    StartCoroutine(SayExitPhrase());
                    animationController.SetBool("walking", true);
                    currTargetPoint = (Random.value > 0.5) ? firstEnterPoint : secondEnterPoint;
                    walkSpeed = 3f;
                    break;
            }
            state = value;
        }
    }

    private HumanState state;

    Vector3 currTargetPoint = Vector3.zero;
    Vector3 firstEnterPoint, secondEnterPoint, lingerCenter;
    public Animator animationController;
    SpriteRenderer humanSprite;
    MoneyHeadScript moneyHead;
    Text phraseText;

    bool firstIdleHappened;

    float walkSpeed;
    float lingerIdleDuration = 1f;
    float currIdleDuration = 0f;

    IEnumerator SayEntryPhrase()
    {
        phraseText.text = entryPhrases[Random.Range(0, entryPhrases.Length)];
        yield return new WaitForSeconds(2f);
        phraseText.text = string.Empty;
    }

    IEnumerator SayExitPhrase()
    {
        phraseText.text = exitPhrases[Random.Range(0, exitPhrases.Length)];
        yield return new WaitForSeconds(2f);
        phraseText.text = string.Empty;
    }

    Vector3 RandPointInLingerZone()
    {
        return new Vector3(lingerCenter.x + Random.Range(-5f, 5f), 0, lingerCenter.z + Random.Range(-3f, 3f));
    }

	// Use this for initialization
	void Start () {
      //  animationController = GetComponentInChildren<Animator>();
        humanSprite = GetComponentInChildren<SpriteRenderer>();
        moneyHead = GetComponentInChildren<MoneyHeadScript>();
        phraseText = GetComponentInChildren<Text>();

        lingerCenter = GameObject.Find("LingerZoneCenter").transform.position;
        firstEnterPoint = GameObject.Find("FirstDoor").transform.position;
        secondEnterPoint = GameObject.Find("SecondDoor").transform.position;

        State = HumanState.LINGERING;
        walkSpeed = 4f;
	}

    public void ShowMoneyEarned()
    {
        if(moneyHead!= null)
        moneyHead.MoneyImagePlayAnim();
    }


	
	// Update is called once per frame
	void Update () {
        Vector3 newPos;
        switch (State)
        {
            case HumanState.LINGERING:
                if (Vector3.Distance(transform.position, currTargetPoint) < 0.1f)
                {
                    State = HumanState.IDLE;
                }

                newPos = Vector3.MoveTowards(transform.position, currTargetPoint, walkSpeed * Time.deltaTime);
                humanSprite.flipX = transform.position.x < newPos.x;
                transform.position = newPos;

                break;
            case HumanState.IDLE:
                currIdleDuration += Time.deltaTime;
                if(currIdleDuration > lingerIdleDuration)
                {
                    currIdleDuration = 0f;
                    State = HumanState.LINGERING;
                }
                break;
            case HumanState.WALKING_OUT:
                if (Vector3.Distance(transform.position, currTargetPoint) < 0.1f)
                {
                    Destroy(gameObject);
                }

                newPos = Vector3.MoveTowards(transform.position, currTargetPoint, walkSpeed * Time.deltaTime);
                humanSprite.flipX = transform.position.x < newPos.x;
                transform.position = newPos;
                break;
        }
    }
}
