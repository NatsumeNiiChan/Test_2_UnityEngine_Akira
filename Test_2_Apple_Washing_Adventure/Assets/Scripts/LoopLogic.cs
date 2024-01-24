using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoopLogic : MonoBehaviour
{
    //[SerializeField] private GameObject[] cubeArray = new GameObject[10];
    [SerializeField] private List<GameObject> appleList;

    //private HealthScript healthScript;

    private void Awake()
    {
        //HitTime();

        for (int i = 0; i < 10; i++)
        {
            appleList[i].GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    //private void HitTime()
    //{
    //    Invoke("HitCube", 3);
    //}

    //private void HitCube()
    //{
    //    foreach (GameObject cube in appleList)
    //    {
    //        healthScript = cube.GetComponent<HealthScript>();

    //        if (healthScript.InDanger == true)
    //        {
    //            healthScript.HealthCount();
    //        }
    //    }

    //    HitTime();
    //}
}
