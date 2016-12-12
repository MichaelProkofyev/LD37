using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour {

    private float coolTime = .5f;
    private float currcoolTime;

    public RectTransform leftHandT;
    private float originalLeftPosX;
    private Animator leftHandAnimation;

    public void TypeSymbol()
    {
        
        currcoolTime = coolTime;
        leftHandAnimation.SetBool("typing", true);
    }

    // Use this for initialization
    void Start () {
        originalLeftPosX = leftHandT.localPosition.x;
        leftHandAnimation = leftHandT.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currcoolTime > 0)
        {
            //print(leftHandT.localPosition.x);
            currcoolTime -= Time.deltaTime;
            if(currcoolTime <= coolTime/2f) leftHandAnimation.SetBool("typing", false);
            float newPositionX = Mathf.Lerp(originalLeftPosX, -33.3f, currcoolTime / coolTime);
            leftHandT.localPosition = new Vector3(newPositionX, leftHandT.localPosition.y, leftHandT.localPosition.z);
        }
    }
}
