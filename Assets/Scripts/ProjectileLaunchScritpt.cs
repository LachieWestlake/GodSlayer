using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ProjectileLaunchScritpt : MonoBehaviour
{
    public int damageAmount;
    public float speed;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Debug.Log(transform.position);
            Rigidbody p = Instantiate(projectile, transform.position, transform.rotation).GetComponent<Rigidbody>();
            p.velocity = transform.forward * speed;
        }
    }
}
