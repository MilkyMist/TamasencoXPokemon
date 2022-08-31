using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingTextAnimations : MonoBehaviour
{
    public Text loadingText;
    public bool isAnimationPlaying = false;

    void Update()
    {
        if (isAnimationPlaying == false)
        {
            isAnimationPlaying = true;
            StartCoroutine("Animation0");
        }
    }

    IEnumerator Animation0()
    {
        yield return new WaitForSeconds(0.3f);
        loadingText.text = "Loading";
        StartCoroutine("Animation1");
    }

    IEnumerator Animation1()
    {
        yield return new WaitForSeconds(0.3f);
        loadingText.text = "Loading.";
        StartCoroutine("Animation2");
    }

    IEnumerator Animation2()
    {
        yield return new WaitForSeconds(0.3f);
        loadingText.text = "Loading..";
        StartCoroutine("Animation3");
    }

    IEnumerator Animation3()
    {
        yield return new WaitForSeconds(0.3f);
        loadingText.text = "Loading...";
        isAnimationPlaying = false;
    }
}
