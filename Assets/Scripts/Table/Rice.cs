using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rice : MonoBehaviour
{
    public void StopScale()
    {
        GetComponent<Scaler>().enabled = false;
        this.transform.localScale = Vector3.one;
    }

    public void Scale()
    {
        GetComponent<Scaler>().enabled = true;
    }
}
