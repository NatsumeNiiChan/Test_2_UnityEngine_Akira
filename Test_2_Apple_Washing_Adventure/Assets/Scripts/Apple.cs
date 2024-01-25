using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool AppleIsRotten = false;
    private bool appleIsClean;
    [SerializeField] private bool isInWater;
    private AudioSource pointsClip;

    private GameManager gameScript;

    [SerializeField] private float timer;


    private void Awake()
    {
        pointsClip = FindObjectOfType<AudioSource>();
        gameScript = FindObjectOfType<GameManager>();

        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        Invoke("KillApple", 10);
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void Update()
    {
        if (AppleIsRotten == true)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            AppleIsRotten = false;
        }

        //while (gameScript.IsWaterClean == true)
        //{
        //    Geht nicht weil es direkt Unity zum abstürzen bringt
        //}

        if (isInWater == true && gameScript.IsWaterClean == true)
        {
            timer += 1 * Time.deltaTime;
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
            pointsClip.Play();
            gameScript.Points++;
            Debug.Log("Apple is in basket");
            GetComponent<DragAndDrop>().enabled = false;
            gameScript.appleList.Remove(gameObject);
            gameScript.cleanAppleList.Add(gameObject);
        }

        else
        {
            Destroy(gameObject);
            gameScript.appleList.Remove(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water" && appleIsClean == false)
        {
            isInWater = true;
        }
    }
}
