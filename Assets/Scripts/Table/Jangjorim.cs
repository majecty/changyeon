using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jangjorim : MonoBehaviour
{
    public void StartRotate()
    {
        GetComponent<Rotator>().enabled = true;
        GetComponent<Rotator>().StartRotate();
    }

    public void StopRotate()
    {
        GetComponent<Rotator>().Stop();
    }
}
