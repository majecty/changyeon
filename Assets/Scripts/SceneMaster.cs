using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour
{
    [SerializeField] private Table table;
    [SerializeField] private BlackScreen blackScreen;

    public void onKitchenEnd()
    {
        table.Show();
        Debug.Log("OnKitchenEnd in scene master");
    }

    public void OnTableRiceClick()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(ShowEat());
    }

    public void OnTableSoupClick()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(ShowEat());
    }

    public void OnTableSausageClick()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(ShowEat());
    }

    private IEnumerator ShowEat()
    {
        yield return blackScreen.FadeIn();

        yield return blackScreen.FadeOut();
    }
}
