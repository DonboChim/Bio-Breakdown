using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroywalls : MonoBehaviour
{
    public float hpoints;
    
   
    // Start is called before the first frame update
   

    // Update is called once per frame
   
    private void OnCollisionStay(Collision collision)
    {
       

        if ((collision.gameObject.tag == "Done" && gameObject.tag == "Done" && hpoints <=0) || (collision.gameObject.tag == "Capturing" && gameObject.tag == "Capturing" && hpoints <= 0))
        {
            collision.gameObject.GetComponent<destroywalls>().hpoints = 0;
            StartCoroutine("Timer");

        }
    }
    public void TakeDamage(float damage)
    {
        hpoints -= damage;
    }
    IEnumerator Timer()
    {

        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);


    }

}
