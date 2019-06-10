using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Eat : MonoBehaviour
{
    [SerializeField] private ArmRotator armRotator;
    [SerializeField] private Blow blow;
    [SerializeField] private Head head;
    [SerializeField] private SpoonAndForkHolder spoonAndForkHolder;
    [SerializeField] private MouseMumble mouseMumble;

    public enum Target
    {
        Rice,
        Soup,
        Sausage
    }

    private Target target = Target.Rice;

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
    public void StartEat(Target target)
    {
        this.target = target;

        if (this.target == Target.Rice)
        {
            spoonAndForkHolder.UseRiceSpoon();
        } else if (this.target == Target.Soup)
        {
            spoonAndForkHolder.UseSoupSpoon();
        }
        else if (this.target == Target.Sausage)
        {
            spoonAndForkHolder.UseSausageFork();
        }

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
        if (this.target != Target.Sausage)
        {
            yield return blow.StartAnimation();
            yield return blow.StartAnimation();
        }
        yield return spoonAndForkHolder.GoToMouse();
        if (this.target == Target.Sausage)
        {
            spoonAndForkHolder.MakeForkEmpty();
        }
        else
        {
            spoonAndForkHolder.MakeSpoonEmpty();
        }
        
        head.CloseTheMouse();
        StartCoroutine(spoonAndForkHolder.RotateRight());
        yield return armRotator.MoveDownFast();
        this.state = State.WaitEyeClick;
        head.StartBlinkEyes();
    }

    IEnumerator ShowEatAnimation()
    {
        if (this.target == Target.Rice || this.target == Target.Sausage)
        {
            yield return mouseMumble.ShakeThirdTimes();
        } else if (this.target == Target.Soup)
        {
            yield return head.MoveMouthNormalSlowly();
        }
        
        head.MakeEyeHappy();
        head.shakePonny();
        head.shakeBangs();
        yield return new WaitForSecondsRealtime(3.0f);
        SceneMaster.Restart();
    }
}
