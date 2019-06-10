using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spoon : MonoBehaviour
{
    [SerializeField] private Table table;

    void OnMouseDown()
    {
        table.OnSpoonClick();
    }
}
