using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blow : MonoBehaviour
{
    private Coroutine animation = null;
    private Vector3 startPosition = new Vector3(-4.5f, -3.5f, -5);
    private Vector3 endPosition = new Vector3(-13f, -8f, -5);
    public IEnumerator StartAnimation()
    {
        GetComponent<SpriteRenderer>().enabled = true;

        if (animation != null)
        {
            Debug.LogError("Blow animation called twice");
            StopCoroutine(animation);
        }

        this.animation = StartCoroutine(Animate());
        yield return animation;
        this.animation = null;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator Animate()
    {
        StartCoroutine(TweenUtil.Alpha(1, 0.2f, 0.5f, GetComponent<SpriteRenderer>()));
        yield return TweenUtil.LocalMove(startPosition, endPosition, 1.0f, transform);
    }
}
