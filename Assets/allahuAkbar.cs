using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allahuAkbar : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    float time;
    
    // Start is called before the first frame update
   

    // Update is called once per frame
   
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Done" ||other.gameObject.tag == "Capturing")
        {

            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        if(other.gameObject.tag == "limit")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
