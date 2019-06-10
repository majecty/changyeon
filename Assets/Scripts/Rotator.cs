using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float angle = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        while (true)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
            yield return null;

            if (transform.rotation.eulerAngles.z > 15 && transform.rotation.eulerAngles.z < 180)
            {
                this.speed = -Mathf.Abs(this.speed);
            }
            else if (transform.rotation.eulerAngles.z > 180 && transform.rotation.eulerAngles.z < 365 - 15)
            {
                this.speed = Mathf.Abs(this.speed);
            }
            Debug.Log(transform.rotation.eulerAngles.z);
        }
    }
}
