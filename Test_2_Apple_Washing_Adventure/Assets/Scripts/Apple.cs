using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    //Festlegen verschiedener Variablen
    public bool AppleIsRotten = false;
    private bool appleIsClean;
    [SerializeField] private bool isInWater;
    private AudioSource pointsClip;

    private GameManager gameScript;

    [SerializeField] private float timer;

    private void Awake()
    {
        //Suche von Variablen
        pointsClip = FindObjectOfType<AudioSource>();
        gameScript = FindObjectOfType<GameManager>();

        //Start des Invokes zum Reifen des Apfels, Position Y freezen, Random Farbe geben
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        Invoke("KillApple", 10);
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }


    private void Update()
    {
        //Apfel constraint verändern wenn er überreif ist
        if (AppleIsRotten == true)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
        }

        //while (gameScript.IsWaterClean == true)
        //{
        //    Geht nicht weil es direkt Unity zum abstürzen bringt
        //}

        //Apfel wird sauber wenn er im Wasser ist und das Wasser sauber ist -> timer zählt hoch
        if (isInWater == true && gameScript.IsWaterClean == true)
        {
            timer += 1 * Time.deltaTime;
        }

        if (timer >= 2)
        {
            CleanApple();
        }
    }

    private void KillApple()
    {
        AppleIsRotten = true;
    }

    //Apfel wird sauber mit nötigen Variabeländerungen
    private void CleanApple()
    {
        isInWater = false;
        timer = 0;
        appleIsClean = true;
        GetComponent<Renderer>().material.color = Color.red;
        pointsClip.Play();
    }

    //Ist der Apfel in einem Trigger wird überprüft ob er sauber ist und dann die nötigen Schritte eingeleitet
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

    //Trifft der Apfel auf einen Collider werden je nach Collision die nötigen Schritte eingeleitet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Water" && appleIsClean == false)
        {
            isInWater = true;
        }

        if (collision.gameObject.tag == "Floor" && AppleIsRotten == true)
        {
            GetComponent<DragAndDrop>().enabled = false;
            gameScript.appleList.Remove(gameObject);
        }
    }
}
