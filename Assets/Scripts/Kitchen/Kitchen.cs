using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private SceneMaster sceneMaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnChairClick()
    {
        sceneMaster.onKitchenEnd();
    }
}
