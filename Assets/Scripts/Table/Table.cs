using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Plate plate;
    [SerializeField] private ForkAndSpoon forkAndSpoon;
    [SerializeField] private Arm arm;

    public void Show()
    {
        StartCoroutine(ShowAnimation());
    }

    IEnumerator ShowAnimation()
    {
        yield return TweenUtil.Move(
            from: transform.position,
            to: new Vector3(0, 0, transform.position.z),
            time: 1f,
            transform: transform
        );

        yield return TweenUtil.Move(
            from: plate.transform.position,
            to: new Vector3(0, 0, plate.transform.position.z),
            time: 1f,
            transform: plate.transform);

        yield return TweenUtil.Move(
            from: forkAndSpoon.transform.position,
            to: new Vector3(0, 0, forkAndSpoon.transform.position.z),
            time: 0.3f,
            transform: forkAndSpoon.transform);

        forkAndSpoon.StartRotate();
    }

    public void OnForkClick()
    {
        StartCoroutine(arm.MoveToFork());
    }

    public void OnSpoonClick()
    {
        StartCoroutine(arm.MoveToSpoon());
    }
}
