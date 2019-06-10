using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    [SerializeField] private ArmRotator armRotator;
    [SerializeField] private Blow blow;
    [SerializeField] private Head head;
    [SerializeField] private SpoonAndForkHolder spoonAndForkHolder;
    [SerializeField] private MouseMumble mouseMumble;

    enum State
    {
        RaisingHand,
        WaitingHeadClick,
        MoveToMouse,
        WaitEyeClick,
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
        if (this.state == State.WaitingHeadClick)
        {
            this.state = State.MoveToMouse;
            head.OpenTheMouse();
            StartCoroutine(ShowMoveToMouseAnimation());
        }
        else if (this.state == State.WaitEyeClick)
        {
            this.state = State.Eating;
            head.StopBlinkEyes();
            StartCoroutine(ShowEatAnimation());
        }
    }

    IEnumerator ShowMoveToMouseAnimation()
    {
        yield return blow.StartAnimation();
        yield return blow.StartAnimation();
        yield return spoonAndForkHolder.GoToMouse();
        spoonAndForkHolder.MakeEmpty();
        head.CloseTheMouse();
        StartCoroutine(spoonAndForkHolder.RotateRight());
        yield return armRotator.MoveDownFast();
        this.state = State.WaitEyeClick;
        head.StartBlinkEyes();
    }

    IEnumerator ShowEatAnimation()
    {
        yield return mouseMumble.ShakeThirdTimes();
    }
}
