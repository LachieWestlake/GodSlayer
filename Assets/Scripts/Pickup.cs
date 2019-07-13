using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Transform onHand;

    void Update()
    {
        //Hit E, pickup object
        if (Input.GetKeyDown(KeyCode.E))
        {
                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = onHand.transform.position;
                this.transform.parent = GameObject.Find("FPSController").transform;
                this.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
         
        }

        //Release E, drop object
        if (Input.GetKeyUp(KeyCode.E))
        {
            
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}