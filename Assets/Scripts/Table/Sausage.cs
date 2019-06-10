using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sausage : MonoBehaviour
{
    [SerializeField] private Table table;
    public void StartRotate()
    {
        GetComponent<Rotator>().enabled = true;
        GetComponent<Rotator>().StartRotate();
    }

    public void StopRotate()
    {
        GetComponent<Rotator>().Stop();
    }

    void OnMouseDown()
    {
        table.OnSausageClick();
    }
}
