using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> appleList;

    private GameObject winScreen;

    private bool createApple = true;
    [SerializeField] private GameObject applePrefab;

    public bool IsWaterClean;
    public int Points;

    private void Awake()
    {
        winScreen = GameObject.Find("Winscreen");
        winScreen.SetActive(false);

        IsWaterClean = true;

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

        if (Points >= 10)
        {
            WinCondition();
        }
    }

    private void CreateApple()
    {
        createApple = true;

        var position = new Vector3(Random.Range(-2.8f, -1.3f), Random.Range(2.8f, 3.35f), Random.Range(-0.5f, 0.5f));
        Instantiate(applePrefab, position, Quaternion.identity);
        appleList.Add(applePrefab);
    }

    private void WinCondition()
    {
        winScreen.SetActive(true);
    }
}
