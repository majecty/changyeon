using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAndSpoon : MonoBehaviour
{
    [SerializeField] public Fork fork;

    [SerializeField] public Spoon spoon;

    public void StartRotate()
    {
        fork.StartRotate();
        spoon.StartRotate();
    }
}
