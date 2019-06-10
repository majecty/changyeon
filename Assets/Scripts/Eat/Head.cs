using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Eat eat;
    [SerializeField] private NormalMouse normalMouse;
    [SerializeField] private OpenMouse OpenMouse;
    [SerializeField] private EyeNormal1 eyeNormal1;
    [SerializeField] private EyeNormal2 eyeNormal2;
    [SerializeField] private EyeHappy eyeHappy;
    [SerializeField] private Ponny ponny;
    [SerializeField] private Bangs bangs;
    private Coroutine blinkingAnimation = null;

    void OnMouseDown()
    {
        eat.OnHeadClick();
    }

    public void OpenTheMouse()
    {
        this.normalMouse.gameObject.SetActive(false);
        this.OpenMouse.gameObject.SetActive(true);
    }

    public void CloseTheMouse()
    {
        this.OpenMouse.gameObject.SetActive(false);
        this.normalMouse.gameObject.SetActive(true);
    }

    public void StartBlinkEyes()
    {
        if (this.blinkingAnimation != null)
        {
            Debug.LogError("Blink called twice");
            StopCoroutine(this.blinkingAnimation);
        }

        this.blinkingAnimation = StartCoroutine(Blink());
    }

    public void StopBlinkEyes()
    {
        if (this.blinkingAnimation == null)
        {
            Debug.LogError("Blink animation already stopped");
            return;
        }
        StopCoroutine(blinkingAnimation);

        this.eyeNormal1.gameObject.SetActive(true);
        this.eyeNormal2.gameObject.SetActive(false);
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            this.eyeNormal1.gameObject.SetActive(true);
            this.eyeNormal2.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(0.3f);
            this.eyeNormal1.gameObject.SetActive(false);
            this.eyeNormal2.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.3f);
        }
    }

    public void MakeEyeHappy()
    {
        this.eyeNormal1.gameObject.SetActive(false);
        this.eyeHappy.gameObject.SetActive(true);
    }

    public void shakePonny()
    {
        ponny.GetComponent<Rotator>().enabled = true;
    }

    public void shakeBangs()
    {
        bangs.GetComponent<Rotator>().enabled = true;
    }

    public IEnumerator MoveMouthNormalSlowly()
    {
        yield return TweenUtil.LocalMove(normalMouse.transform.position, new Vector3(0, 0.2f, -1), 1.0f, normalMouse.transform);
        yield return TweenUtil.LocalMove(normalMouse.transform.position, new Vector3(0, -0.2f, -1), 1.0f, normalMouse.transform);
        yield return TweenUtil.LocalMove(normalMouse.transform.position, new Vector3(0, 0, -1), 1.0f, normalMouse.transform);
    }
}
