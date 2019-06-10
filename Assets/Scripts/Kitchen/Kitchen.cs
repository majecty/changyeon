using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private SceneMaster sceneMaster;
    [SerializeField] private Chair chair;
    private bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnChairClick()
    {
        if (end)
        {
            return;
        }

        StartCoroutine(WaitAndEnd());

        end = true;
        
    }

    IEnumerator WaitAndEnd()
    {
        yield return chair.StartAnimation();
        sceneMaster.onKitchenEnd();
    }
}
