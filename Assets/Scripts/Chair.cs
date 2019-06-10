using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private Kitchen kitchen;
    void OnMouseDown()
    {
        kitchen.OnChairClick();
    }

    public IEnumerator StartAnimation()
    {
        GetComponent<Rotator>().Stop();
        yield return TweenUtil.Move(from: transform.position,
            to: new Vector3(5, transform.position.y, transform.position.z),
            time: 1,
            transform: transform);
    }
}
