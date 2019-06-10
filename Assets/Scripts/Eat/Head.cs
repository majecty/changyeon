using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Eat eat;
    [SerializeField] private NormalMouse normalMouse;
    [SerializeField] private OpenMouse OpenMouse;

    void OnMouseDown()
    {
        eat.OnHeadClick();
    }

    public void OpenTheMouse()
    {
        this.normalMouse.gameObject.SetActive(false);
        this.OpenMouse.gameObject.SetActive(true);
    }

    public void CloseTheMouse()
    {
        this.OpenMouse.gameObject.SetActive(false);
        this.normalMouse.gameObject.SetActive(true);
    }
}
