using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonAndForkHolder : MonoBehaviour
{
    [SerializeField] private SpoonRice spoonRice;
    [SerializeField] private SpoonSoup spoonSoup;
    [SerializeField] private SpoonEmpty spoonEmpty;
    [SerializeField] private ForkSausage forkSausage;
    [SerializeField] private ForkEmpty forkEmpty;

    private Coroutine coroutine = null;
    public IEnumerator GoToMouse()
    {
        this.GetComponent<RotationFixer>().enabled = false;
        if (this.coroutine != null)
        {
            Debug.LogError("GoToMouse called twice");
            StopCoroutine(this.coroutine);
        }

        this.coroutine = StartCoroutine(Animate());
        yield return this.coroutine;
        this.coroutine = null;
    }

    IEnumerator Animate()
    {
        yield return TweenUtil.Rotate(eulerFrom: transform.eulerAngles, eulerTo: new Vector3(0, 0, 20), 1.0f, transform);
    }

    public void MakeSpoonEmpty()
    {
        spoonRice.gameObject.SetActive(false);
        spoonSoup.gameObject.SetActive(false);
        spoonEmpty.gameObject.SetActive(true);
    }

    public void MakeForkEmpty()
    {
        forkSausage.gameObject.SetActive(false);
        forkEmpty.gameObject.SetActive(true);
    }

    public IEnumerator RotateRight()
    {
        yield return TweenUtil.Rotate(eulerFrom: transform.eulerAngles, eulerTo: new Vector3(0, 0, 0), 0.5f, transform);
    }

    public void UseRiceSpoon()
    {
        spoonRice.gameObject.SetActive(true);
        spoonSoup.gameObject.SetActive(false);
        spoonEmpty.gameObject.SetActive(false);
    }

    public void UseSoupSpoon()
    {
        spoonRice.gameObject.SetActive(false);
        spoonSoup.gameObject.SetActive(true);
        spoonEmpty.gameObject.SetActive(false);
    }

    public void UseSausageFork()
    {
        spoonRice.gameObject.SetActive(false);
        forkSausage.gameObject.SetActive(true);
    }
}
