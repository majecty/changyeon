using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour
{
    [SerializeField] private Table table;
    [SerializeField] private BlackScreen blackScreen;
    [SerializeField] private Eat eat;

    public void onKitchenEnd()
    {
        table.Show();
        Debug.Log("OnKitchenEnd in scene master");
    }

    public void OnTableRiceClick()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(ShowEat(Eat.Target.Rice));
    }

    public void OnTableSoupClick()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(ShowEat(Eat.Target.Soup));
    }

    public void OnTableSausageClick()
    {
        blackScreen.gameObject.SetActive(true);
        StartCoroutine(ShowEat(Eat.Target.Sausage));
    }

    private IEnumerator ShowEat(Eat.Target target)
    {
        yield return blackScreen.FadeIn();
        eat.transform.position = new Vector3(0, 0, -30);
        eat.StartEat(target);
        yield return blackScreen.FadeOut();
    }
}
