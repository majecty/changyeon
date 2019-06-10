using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Eat eat;
    void OnMouseDown()
    {
        eat.OnHeadClick();
    }
}
