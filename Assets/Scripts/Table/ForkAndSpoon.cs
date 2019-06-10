using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkAndSpoon : MonoBehaviour
{
    [SerializeField] public Fork fork;

    [SerializeField] public Spoon spoon;

    public void StartRotate()
    {
        fork.GetComponent<Rotator>().enabled = true;
        spoon.GetComponent<Rotator>().enabled = true;
    }
}
