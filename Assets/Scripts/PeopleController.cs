using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleController : MonoBehaviour {

    public GameController gameController;
    public Animator boredTextAnim;

    public UIController uiController;
    public GameObject unclePrefab, grannyPrefab, rebelPrefab, twinsPrefab, chocolatePrefab, dogPrefab, womanPrefab;
    List<Human> people = new List<Human>();

    Vector3 firstEnterPoint, secondEnterPoint;
    float cashAddRate = 2f;
    float lastcashAdd = 0f;

    float happinessReduceRate = 3;
    float lastHappinessReduce = 0f;

    int[] happinessMilestones = new int[7]{20, 40, 70, 115, 143, 171, 200};

    public void HappinessIncreased(float oldHappiness, float newHappiness) {
        for (int i = 0; i < happinessMilestones.Length; i++) {
            bool crossedMileStone = oldHappiness < happinessMilestones[i] && happinessMilestones[i] <= newHappiness;
            if (crossedMileStone) {
                GameObject newHuman;
                Vector3 spawnPosition = (Random.value > 0.5) ? firstEnterPoint : secondEnterPoint;
                if (i==0) {
                    newHuman = Instantiate(grannyPrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }else if (i == 1) {
                    newHuman = Instantiate(unclePrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }
                else if (i == 2){
                    newHuman = Instantiate(twinsPrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }else if (i == 3) {
                    newHuman = Instantiate(rebelPrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }else if (i == 4)
                {
                    newHuman = Instantiate(chocolatePrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }else if (i == 5)
                {
                    newHuman = Instantiate(dogPrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }else if (i == 6)
                {
                    newHuman = Instantiate(womanPrefab, spawnPosition, Quaternion.identity);
                    people.Add(newHuman.GetComponent<Human>());
                }
            }
        }
    }

    public void HappinessDecreased(float oldHappiness, float newHappiness)
    {
        for (int i = 0; i < happinessMilestones.Length; i++)
        {
            bool crossedMileStone = happinessMilestones[i] <= oldHappiness &&  newHappiness < happinessMilestones[i];
            if (crossedMileStone)
            {
                people[people.Count - 1].State = HumanState.WALKING_OUT;
                boredTextAnim.Play("MemberLeft");

                people.RemoveAt(people.Count - 1);
                uiController.ShakeCharm();
            }
        }
    }


        // Use this for initialization
        void Start () {
        firstEnterPoint = GameObject.Find("FirstDoor").transform.position;
        secondEnterPoint = GameObject.Find("SecondDoor").transform.position;
    }


	
	// Update is called once per frame
	void Update () {
        if(people.Count > 0)
        {
            lastcashAdd += Time.deltaTime;

            lastHappinessReduce += Time.deltaTime;

            if (lastcashAdd > cashAddRate) {
                //gameController.Cash += 1;
                gameController.Cash += people.Count * 6;
                foreach (var human in people)
                {
                    human.ShowMoneyEarned();
                }
                lastcashAdd = 0f;
            }

            if (lastHappinessReduce > happinessReduceRate)
            {
                if(gameController.Happiness > 0)
                {
                    gameController.Happiness -= 1;//BOREDOM
                    lastHappinessReduce = 0f;
                }
            }
        }
       

    }
}
