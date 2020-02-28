using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallattack : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBetweenAttacks ;
    public int attackDamage ;


   
    
    
    bool playerInRange;
    float timer;


    void Awake()
    {
       
       
       
       
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Done" || other.gameObject.tag == "Capturing")
        {
            playerInRange = true;
            if (timer >= timeBetweenAttacks && playerInRange && other.gameObject.GetComponent<destroywalls>().hpoints != 0)
            {
                timer = 0f;

                if (other.gameObject.GetComponent<destroywalls>().hpoints != 0)
                {
                    other.gameObject.GetComponent<destroywalls>().TakeDamage(attackDamage);
                }
            }
        }
       



    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GeneratorOn")
        {
            playerInRange = true;
            if (timer >= timeBetweenAttacks && playerInRange && other.gameObject.GetComponent<isActivated>().hpoints != 0)
            {


                if (other.gameObject.GetComponent<isActivated>().hpoints != 0)
                {
                    other.gameObject.GetComponent<isActivated>().TakeDamage(attackDamage);
                }
                timer = 0f;
            }
        }
    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Done" || other.gameObject.tag == "Capturing")
        {
            playerInRange = false;
        }
        if(other.gameObject.tag == "GeneratorOn")
        {
            playerInRange = false;
        }
       
    }


    void Update()
    {
        timer += Time.deltaTime;

        
    }


   
}
