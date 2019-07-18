using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // on collision, deal damage to the colided object if it has health (if it has a DeductHealth method)
        collision.gameObject.transform.SendMessage("DeductHealth", damageAmount, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
