using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HitscanDamageScript : MonoBehaviour
{
    public int damageAmount = 1;
    public float targetDistance;
    public float allowedRange = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            RaycastHit shot;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot))
            {
                targetDistance = shot.distance;

                if (targetDistance <= allowedRange)
                {
                    shot.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
