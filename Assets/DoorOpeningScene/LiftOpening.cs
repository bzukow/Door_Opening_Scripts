using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftOpening : MonoBehaviour
{
    public bool autoDoor;
    bool doorOpened;
    public BoxCollider doorCollider;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Zul") && autoDoor)
        {
            GetComponent<AudioSource>().Play();
        }
    }
    void OnTriggerStay(Collider collider)
    {
        
        if (collider.CompareTag("Zul") && autoDoor)
        {
            transform.GetComponent<Animator>().SetBool("Opening", true);
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Zul") && autoDoor)
        {
            GetComponent<AudioSource>().Play();
            transform.GetComponent<Animator>().SetBool("Opening", false);
        }
    }

    public void ToggleDoor()
    {
        if (!autoDoor)
        {
            if (!doorOpened)
            {
                GetComponent<AudioSource>().Play();
                doorOpened = true;
                transform.GetComponent<Animator>().SetBool("Opening", true);
                doorCollider.enabled = false;

            } else
            {
                GetComponent<AudioSource>().Play();
                doorOpened = false;
                transform.GetComponent<Animator>().SetBool("Opening", false);
                doorCollider.enabled = true;
            }
            
        }
    }
}
