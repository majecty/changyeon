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

    private Vector3 startPosition = Vector3.zero;

    private void Start()
    {
        this.startPosition = transform.localPosition;
    }

    public void ResetPosition()
    {
        this.transform.localPosition = this.startPosition;
    }

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
