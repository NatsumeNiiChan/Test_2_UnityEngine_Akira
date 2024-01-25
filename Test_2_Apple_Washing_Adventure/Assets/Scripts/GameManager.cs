using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> appleList;

    private Apple appleScript;

    private bool createApple = true;
    [SerializeField] private GameObject applePrefab;

    private void Awake()
    {
        //HitTime();

        foreach (GameObject apple in appleList)
        {
            apple.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }

    private void Update()
    {
        if (createApple == true)
        {
            createApple = false;
            Invoke("CreateApple", 8);
        }
    }

    private void CreateApple()
    {
        createApple = true;

        var position = new Vector3(Random.Range(-2.8f, -1.3f), Random.Range(2.8f, 3.35f), Random.Range(-0.5f, 0.5f));
        Instantiate(applePrefab, position, Quaternion.identity);
        applePrefab.GetComponent<Renderer>().material.color = Random.ColorHSV();
        //appleScript = applePrefab.GetComponent<Apple>();
        appleList.Add(applePrefab);

        //applePrefab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        //Invoke("appleScript.KillApple", 2);
    }

    //private void KillApple()
    //{
        
    //    appleScript.AppleIsRotten = true;
    //    //applePrefab.GetComponent<Rigidbody>().constraints &= RigidbodyConstraints.FreezePositionY;
    //}

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
