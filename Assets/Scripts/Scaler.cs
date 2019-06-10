using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float from = 0.9f;

    [SerializeField] private float to = 1.1f;

    [SerializeField] private float time = 0.5f;
    // Start is called before the first frame update
    private Coroutine coroutine = null;
    void OnEnable()
    {
        if (this.coroutine != null)
        {
            Debug.LogError("Coroutine duplicated");
            StopCoroutine(coroutine);
            coroutine = null;
        }
        this.coroutine = StartCoroutine(StartAnimation());
    }

    void OnDisable()
    {
        if (this.coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator StartAnimation()
    {
        while (true)
        {
            yield return TweenUtil.Scale(from: @from, to: to, time: time, transform: transform);
            yield return TweenUtil.Scale(from: to, to: from, time: time, transform: transform);
        }
    }
}
