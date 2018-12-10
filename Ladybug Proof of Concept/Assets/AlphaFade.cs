using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaFade : MonoBehaviour
{

    Color alpha;
    public float fadeSpeed;

    private void Update()
    {
        if(GetComponent<Image>().color.a != 0f){
            alpha = new Color(0f, 0f, 0f, Mathf.Lerp(GetComponent<Image>().color.a, 0f, Time.deltaTime * fadeSpeed));
            GetComponent<Image>().color = alpha;
        }
    }
}

