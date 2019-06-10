using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonAndForkHolder : MonoBehaviour
{
    [SerializeField] private SpoonRice spoonRice;
    [SerializeField] private SpoonSoup spoonSoup;
    [SerializeField] private SpoonEmpty spoonEmpty;

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

    public void MakeEmpty()
    {
        spoonRice.gameObject.SetActive(false);
        spoonSoup.gameObject.SetActive(false);
        spoonEmpty.gameObject.SetActive(true);
    }
}
