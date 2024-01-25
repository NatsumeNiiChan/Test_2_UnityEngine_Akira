using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool AppleIsRotten = false;
    private bool appleIsClean;
    [SerializeField] private bool isInWater;

    private GameManager gameScript;

    [SerializeField] private float timer;


    private void Awake()
    {
        gameScript = FindObjectOfType<GameManager>();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        Invoke("KillApple", 10);
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (AppleIsRotten == true)
        {
            Debug.Log("rotten");
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            AppleIsRotten = false;
        }

        if (isInWater == true && gameScript.IsWaterClean == true)
        {
            Debug.Log("timer");
            timer += 1 * Time.deltaTime;

            //while (gameScript.isWaterClean == true)
            //{
            //      Geht nicht weil es direkt Unity zum abst�rzen bringt
            //}
        }

        if (timer >= 2)
        {
            CleanApple();
        }
    }

    public void KillApple()
    {
        AppleIsRotten = true;
    }

    private void CleanApple()
    {
        isInWater = false;
        timer = 0;
        appleIsClean = true;
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (appleIsClean == true)
        {
            gameScript.Points++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water" && appleIsClean == false)
        {
            Debug.Log("in Water");
            isInWater = true;
        }
    }
}
