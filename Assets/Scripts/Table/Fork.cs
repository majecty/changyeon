using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : MonoBehaviour
{
    [SerializeField] private Table table;

    void OnMouseDown()
    {
        table.OnForkClick();
    }
}
