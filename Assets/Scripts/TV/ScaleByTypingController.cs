using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleByTypingController : MonoBehaviour {

    RectTransform rectT;

    public Text mashText;
    private float maxLocalScale = 0.02f;
    private float coolTime = .5f;
    private float currcoolTime;
    private float minScale;

    // Use this for initialization
    void Start()
    {
        rectT = GetComponent<RectTransform>();
      //  mashText = GetComponent<Text>();
        minScale = rectT.localScale.x;

    }

    public void SetText(string newText)
    {
        mashText.text = newText;
    }

    public void AddScale()
    {
        currcoolTime = coolTime;

    }

    // Update is called once per frame
    void Update()
    {
       // mashText.color = RandomColor();

        if (currcoolTime > 0)
        {
            currcoolTime -= Time.deltaTime;
            float newScale = Mathf.Lerp(minScale, maxLocalScale, currcoolTime / coolTime);
            rectT.localScale = new Vector3(newScale, newScale, rectT.localScale.z);
        }
    }

    Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}






   
