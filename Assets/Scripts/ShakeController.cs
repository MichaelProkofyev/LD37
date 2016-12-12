using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour {

    RectTransform rectT;


    //Shake vars
    float maxShift = 5f;

    float currentShiftX;

    float originalPosX;
    float coolTime = .5f;
    float currcoolTime;

    public void Shake()
    {
        currcoolTime = coolTime;
    }

    void Start() {
        rectT = GetComponent<RectTransform>();
        originalPosX = rectT.localPosition.x;
        currentShiftX = originalPosX;
    }

    // Update is called once per frame
    void Update () {
        if (currcoolTime > 0)
        {
            //print(leftHandT.localPosition.x);

            currcoolTime -= Time.deltaTime;
            maxShift *= -1;
            float currMaxShift = originalPosX + maxShift;
            float newPositionX = Mathf.Lerp(originalPosX, currMaxShift, currcoolTime / coolTime);
            rectT.localPosition = new Vector3(newPositionX, rectT.localPosition.y, rectT.localPosition.z);
        }
    }
}
