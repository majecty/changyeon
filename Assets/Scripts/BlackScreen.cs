using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    private Coroutine fadeCoroutine = null;
    public IEnumerator FadeIn()
    {
        if (this.fadeCoroutine != null)
        {
            Debug.LogError("FadeIn called twice");
            StopCoroutine(fadeCoroutine);
        }
        this.fadeCoroutine = StartCoroutine(FadeInAnimation());
        yield return this.fadeCoroutine;
        this.fadeCoroutine = null;
    }

    IEnumerator FadeInAnimation()
    {
        yield return TweenUtil.Alpha(0, 1, 0.5f, GetComponent<SpriteRenderer>());
    }

    public IEnumerator FadeOut()
    {
        if (this.fadeCoroutine != null)
        {
            Debug.LogError("FadeIn called twice");
            StopCoroutine(fadeCoroutine);
        }

        this.fadeCoroutine = StartCoroutine(FadeOutAnimation());
        yield return this.fadeCoroutine;
        this.fadeCoroutine = null;
        this.gameObject.SetActive(false);
    }

    IEnumerator FadeOutAnimation()
    {
        yield return TweenUtil.Alpha(1, 0, 0.5f, GetComponent<SpriteRenderer>());
    }
}
