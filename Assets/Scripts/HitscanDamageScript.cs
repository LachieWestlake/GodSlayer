using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HitscanDamageScript : MonoBehaviour
{
    public int damageAmount;
    public float targetDistance;
    public float allowedRange;
    public LayerMask toIgnore;
    public GameObject impactPoint;

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

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out shot, allowedRange, ~toIgnore))
            {
                Debug.Log(shot.collider);
                targetDistance = shot.distance;

                Instantiate(impactPoint, shot.point, Quaternion.identity);

                shot.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
