using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsAutoScaler : MonoBehaviour {

    RectTransform rectT;

    //Scaling vars
    float maxScale;
    float minScale;
    float scaleSpeed = 0.005f;

    // Use this for initialization
    void Start () {
        rectT = GetComponent<RectTransform>();
        maxScale = rectT.localScale.x;
        minScale = maxScale * 0.7f; ;

    }

    // Update is called once per frame
    void Update () {
        //Scaling
        if (rectT.localScale.x >= maxScale) scaleSpeed = -1 * Mathf.Abs(scaleSpeed);
        else if (rectT.localScale.x <= minScale) scaleSpeed = Mathf.Abs(scaleSpeed);

        float newLocalScale = rectT.localScale.x + Time.deltaTime * scaleSpeed;
        rectT.localScale = new Vector3(newLocalScale, newLocalScale, rectT.localScale.z);
    }
}
