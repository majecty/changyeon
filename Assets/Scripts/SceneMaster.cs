using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour
{
    [SerializeField] private Table table;

    public void onKitchenEnd()
    {
        table.Show();
        Debug.Log("OnKitchenEnd in scene master");
    }
}
