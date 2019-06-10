using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private Vector3 spoonPosition = new Vector3(13, -6, -20);

    [SerializeField] private Vector3 forkPosition = new Vector3(15, -6, -20);
    [SerializeField] private Vector3 ricePosition = new Vector3(-1, -13, -20);
    [SerializeField] private Vector3 soupPosition = new Vector3(7, -13, -20);
    [SerializeField] private Vector3 sausagePosition = new Vector3(4, -8, -20);

    [SerializeField] private GameObject hand1;
    [SerializeField] private GameObject hand2;

    private Vector3 startPosition = Vector3.zero;

    private Coroutine moveCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = transform.position;
    }

    public IEnumerator MoveToSpoon()
    {
        hand1.SetActive(true);
        hand2.SetActive(false);
        if (this.moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        this.moveCoroutine = StartCoroutine(TweenUtil.Move(from: transform.position, to: spoonPosition, 1f, transform));
        yield return moveCoroutine;
        hand1.SetActive(false);
        hand2.SetActive(true);
    }

    public IEnumerator MoveToFork()
    {
        hand1.SetActive(true);
        hand2.SetActive(false);
        if (this.moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        this.moveCoroutine = StartCoroutine(TweenUtil.Move(from: transform.position, to: forkPosition, 1f, transform));
        yield return moveCoroutine;
        hand1.SetActive(false);
        hand2.SetActive(true);
    }

    public IEnumerator MoveToRice()
    {
        hand1.SetActive(false);
        hand2.SetActive(true);
        if (this.moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        this.moveCoroutine = StartCoroutine(TweenUtil.Move(from: transform.position, to: ricePosition, 1f, transform));
        yield return moveCoroutine;
    }

    public IEnumerator MoveToSoup()
    {
        hand1.SetActive(false);
        hand2.SetActive(true);
        if (this.moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        this.moveCoroutine = StartCoroutine(TweenUtil.Move(from: transform.position, to: soupPosition, 1f, transform));
        yield return this.moveCoroutine;
    }

    public IEnumerator MoveToSausage()
    {
        hand1.SetActive(false);
        hand2.SetActive(true);
        if (this.moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        this.moveCoroutine = StartCoroutine(TweenUtil.Move(from: transform.position, to: sausagePosition, 1f, transform));
        yield return this.moveCoroutine;
    }
}
