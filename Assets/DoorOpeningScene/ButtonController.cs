using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    Animator anim;
    Animator zulAnim;
    bool isTriggered;
    public LiftOpening doorRef;
 
    bool clickStun;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        zulAnim = GameObject.FindGameObjectWithTag("Zul").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.Space)&&!clickStun)
            {
                if (!zulAnim.GetBool("heClicked"))
                {
                    zulAnim.SetBool("heClicked", true);
                    zulAnim.transform.GetComponent<ZulController>().stunned = true;
                }
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Zul"))
        {
            isTriggered = true;

        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Zul"))
        {
            isTriggered = false;
        }
    }

    void FinishAnimation()
    {
        anim.SetBool("isClicked", false);
        zulAnim.SetBool("heClicked", false);
        zulAnim.transform.GetComponent<ZulController>().stunned = false;
        
    }

    void OpenDoor()
    {
        doorRef.ToggleDoor();
    }
}
