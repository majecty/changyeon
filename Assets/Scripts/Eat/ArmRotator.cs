using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    public IEnumerator MoveDownFast()
    {
        yield return TweenUtil.Rotate(eulerFrom: transform.eulerAngles, eulerTo: new Vector3(0, 0, 60), 0.5f, transform);
    }
}
