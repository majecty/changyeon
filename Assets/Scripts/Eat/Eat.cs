using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private ArmRotator armRotator;
    [SerializeField] private Blow blow;

    enum State
    {
        RaisingHand,
        WaitingHeadClick,
        Eating,
    }

    private State state = State.RaisingHand;

    // Start is called before the first frame update
    void Start()
    {
        this.state = State.RaisingHand;
        StartCoroutine(RaiseHand());
    }

    IEnumerator RaiseHand()
    {
        yield return TweenUtil.Rotate(armRotator.transform.eulerAngles, Vector3.zero, 1, armRotator.transform);
        this.state = State.WaitingHeadClick;
    }

    public void OnHeadClick()
    {
        if (this.state != State.WaitingHeadClick)
        {
            return;
        }

        this.state = State.Eating;
        StartCoroutine(ShowEatAnimation());
    }

    IEnumerator ShowEatAnimation()
    {
        yield return blow.StartAnimation();
        yield return blow.StartAnimation();
    }
}
