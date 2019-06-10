using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMumble : MonoBehaviour
{
    public IEnumerator ShakeThirdTimes()
    {
        this.gameObject.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            yield return TweenUtil.LocalMove(transform.position, new Vector3(0, 0.2f, -1), 1.0f, transform);
            yield return TweenUtil.LocalMove(transform.position, new Vector3(0, -0.2f, -1), 1.0f, transform);
        }

        transform.position = new Vector3(0, 0, -1);
        this.gameObject.SetActive(false);
    }
}
