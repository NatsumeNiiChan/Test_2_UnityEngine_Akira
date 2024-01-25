using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    //Variablen werden festgelegt
    private GameManager gameScript;
    private Vector3 mousePosition;
    private bool waterGettingDirty;

    //Variablen werden Gesucht
    private void Awake()
    {
        gameScript = FindObjectOfType<GameManager>();
    }

    //Mausposition wird berechnet
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void Update()
    {
        //Wasser verdrecken wird eingeleitet
        if (gameScript.IsWaterClean == true && waterGettingDirty == false)
        {
            waterGettingDirty = true;
            Invoke("DirtyWater", 8);
        }
    }

    //Wasser wird dreckig
    private void DirtyWater()
    {
        gameScript.IsWaterClean = false;
        GetComponent<Renderer>().material.color = Color.green;
    }

    //Wasser wird sauber wenn es angeklickt wird
    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
        waterGettingDirty = false;
        gameScript.IsWaterClean = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
