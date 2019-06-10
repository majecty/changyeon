using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private Plate plate;
    [SerializeField] private ForkAndSpoon forkAndSpoon;
    [SerializeField] private Arm arm;
    [SerializeField] private Rice rice;
    [SerializeField] private Soup soup;

    enum Grapped
    {
        None,
        Spoon,
        Fork
    }

    private Grapped grapped = Grapped.None;
    private Coroutine grapCoroutine = null;

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
        if (this.grapped == Grapped.Fork)
        {
            return;
        }
        rice.StopScale();
        soup.StopScale();
        if (this.grapCoroutine != null)
        {
            StopCoroutine(this.grapCoroutine);
        }
        this.grapCoroutine = StartCoroutine(GrabFork());
    }

    IEnumerator GrabFork()
    {
        this.grapped = Grapped.None;
        forkAndSpoon.spoon.transform.SetParent(forkAndSpoon.transform);
        forkAndSpoon.spoon.ResetPosition();
        forkAndSpoon.spoon.StartRotate();
        yield return arm.MoveToFork();
        forkAndSpoon.fork.StopRotate();
        this.grapped = Grapped.Fork;
        forkAndSpoon.fork.transform.SetParent(arm.gameObject.transform);
    }

    public void OnSpoonClick()
    {
        if (this.grapped == Grapped.Spoon)
        {
            return;
        }
        if (this.grapCoroutine != null)
        {
            StopCoroutine(this.grapCoroutine);
        }
        this.grapCoroutine = StartCoroutine(GrabSpoon());
    }

    IEnumerator GrabSpoon()
    {
        this.grapped = Grapped.None;
        forkAndSpoon.fork.transform.SetParent(forkAndSpoon.transform);
        forkAndSpoon.fork.ResetPosition();
        forkAndSpoon.fork.StartRotate();
        yield return arm.MoveToSpoon();
        forkAndSpoon.spoon.transform.SetParent(arm.gameObject.transform);
        this.grapped = Grapped.Spoon;
        forkAndSpoon.spoon.StopRotate();
        rice.Scale();
        soup.Scale();
    }

    public void OnRiceClick()
    {
        if (this.grapped != Grapped.Spoon)
        {
            return;
        }
        StartCoroutine(arm.MoveToRice());
    }

    public void OnSoupClick()
    {
        if (this.grapped != Grapped.Spoon)
        {
            return;
        }
        StartCoroutine(arm.MoveToSoup());
    }
}
