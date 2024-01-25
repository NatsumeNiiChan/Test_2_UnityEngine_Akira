using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private GameManager gameScript;
    private Vector3 mousePosition;
    private bool waterGettingDirty;

    private void Awake()
    {
        gameScript = FindObjectOfType<GameManager>();
    }

    private Vector3 GetMousePos()
    {
        //print("calculate now");
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void Update()
    {
        if (gameScript.IsWaterClean == true && waterGettingDirty == false)
        {
            waterGettingDirty = true;
            Invoke("DirtyWater", 8);
        }
    }

    private void DirtyWater()
    {
        gameScript.IsWaterClean = false;
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        waterGettingDirty = false;
        gameScript.IsWaterClean = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
