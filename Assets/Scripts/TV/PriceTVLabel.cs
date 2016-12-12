using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceTVLabel : MonoBehaviour {

    RectTransform rectT;
    public Text priceText;

    //Scaling vars
    float maxScale = 0.04f;
    float minScale;
    float scaleSpeed = 0.04f;

    //Shake vars
    float maxShift = 0.1f;
    float originalPosX;
    float coolTime = .5f;
    float currcoolTime;

    public void Shake () {
        currcoolTime = coolTime;
    }

    public void SetPrice(float newPrice)
    {
        priceText.text = newPrice + "$";
    }

    void Start () {
        rectT = GetComponent<RectTransform>();
        minScale = rectT.localScale.x;

        originalPosX = rectT.localPosition.x;
    }
	
	void Update () {

        //Shaking
        if (currcoolTime > 0)
        {
            //print(leftHandT.localPosition.x);

            currcoolTime -= Time.deltaTime;
            maxShift *= -1;
            float currMaxShift = originalPosX + maxShift;
            float newPositionX = Mathf.Lerp(originalPosX, currMaxShift, currcoolTime / coolTime);
            rectT.localPosition = new Vector3(newPositionX, rectT.localPosition.y, rectT.localPosition.z);
        }


        //Scaling
        if (rectT.localScale.x >= maxScale) scaleSpeed = -1 * Mathf.Abs(scaleSpeed);
        else if (rectT.localScale.x <= minScale) scaleSpeed = Mathf.Abs(scaleSpeed);

        float newLocalScale = rectT.localScale.x + Time.deltaTime * scaleSpeed;
        rectT.localScale = new Vector3(newLocalScale, newLocalScale, rectT.localScale.z);

    }

}
