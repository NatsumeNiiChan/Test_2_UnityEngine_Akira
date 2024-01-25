using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool AppleIsRotten = false;


    private void Awake()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        Invoke("KillApple", 10);
    }

    private void Update()
    {
        if (AppleIsRotten == true)
        {
            Debug.Log("rotten");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            AppleIsRotten = false;
        }
    }

    public void KillApple()
    {
        AppleIsRotten = true;
    }

    private void CleanApple()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }
}
