using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PickUpScan : MonoBehaviour
{
    public bool currentlyPickedUp;
    public float targetDistance;
    public float allowedRange = 15;
    public RaycastHit pickUpRaycastHit;
    public Transform onHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && currentlyPickedUp)
        {
            pickUpRaycastHit.collider.gameObject.transform.parent = null;
            pickUpRaycastHit.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            pickUpRaycastHit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            currentlyPickedUp = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out pickUpRaycastHit) && currentlyPickedUp == false)
            {
                targetDistance = pickUpRaycastHit.distance;

                if (targetDistance <= allowedRange)
                {
                    pickUpRaycastHit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    pickUpRaycastHit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    pickUpRaycastHit.collider.gameObject.transform.position = new Vector3(onHand.transform.position.x, onHand.transform.position.y , onHand.transform.position.z); 
                    pickUpRaycastHit.collider.gameObject.transform.parent = GameObject.Find("FPSController").transform;
                    pickUpRaycastHit.collider.gameObject.transform.parent = GameObject.Find("FirstPersonCharacter").transform;
                    currentlyPickedUp = true;
                }
            }
        }
    }
}
