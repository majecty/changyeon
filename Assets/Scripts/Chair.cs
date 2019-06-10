using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private Kitchen kitchen;
    void OnMouseDown()
    {
        kitchen.onChairClick();
    }
}
