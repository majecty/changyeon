using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private Vector3 spoonPosition = new Vector3(13, -6, -20);

    [SerializeField] private Vector3 forkPosition = new Vector3(15, -6, -20);

    [SerializeField] private GameObject hand1;
    [SerializeField] private GameObject hand2;

    private Vector3 startPosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = transform.position;
    }

    public IEnumerator MoveToSpoon()
    {
        hand1.SetActive(true);
        hand2.SetActive(false);
        yield return TweenUtil.Move(from: transform.position, to: spoonPosition, 1f, transform);
        hand1.SetActive(false);
        hand2.SetActive(true);
    }

    public IEnumerator MoveToFork()
    {
        hand1.SetActive(true);
        hand2.SetActive(false);
        yield return TweenUtil.Move(from: transform.position, to: forkPosition, 1f, transform);
        hand1.SetActive(false);
        hand2.SetActive(true);
    }
}
