using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//by Shubing Zhou
public class FadeAway : MonoBehaviour
{
    public float fadeDuration;
    public TextMeshProUGUI fadeAwayText;
    private float alphaValue;
    private float fadeAwayPerSec;

    // Start is called before the first frame update
    void Start()
    {
        fadeAwayText = GetComponent<TextMeshProUGUI>();
        fadeAwayPerSec = 1 / fadeDuration;
        alphaValue = fadeAwayText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeDuration > 0)
        {
            //change color
            fadeDuration -= Time.deltaTime;
            fadeAwayText.color = new Color(fadeAwayText.color.r, fadeAwayText.color.g, fadeAwayText.color.b, fadeDuration);
        }
    }
}