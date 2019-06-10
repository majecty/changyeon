﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TweenUtil
{
    public static IEnumerator Move(Vector3 from, Vector3 to, float time, Transform transform)
    {
        var x = 0f;
        while (true)
        {
            if (x > 1)
            {
                x = 1;
            }
            transform.position = Vector3.Lerp(from, to, x);

            if (x == 1)
            {
                yield break;
            }

            x += Time.deltaTime / time;
            yield return null;
        }
    }
}