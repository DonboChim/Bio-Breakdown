using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    // This element is not "public" because the enemies are instantiated during gameplay, so the reference to the player needs to be established at runtime.
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    float distanceBetween;
    Recolector recolector;
   
    [SerializeField]string type;
    [SerializeField]bool activated;
    [SerializeField] bool following;
    
    public GameObject[] donewalls;
    public GameObject[] generadores;
    public float[] wallsdistances;
    public float[] generatordistances;
    
   


    void Awake ()
    {
        recolector = GameObject.FindGameObjectWithTag("Player").GetComponent<Recolector>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent>();
    }


    void Update ()
    {
        distanceBetween = Vector3.Distance(gameObject.transform.position, player.position);
        if (distanceBetween <= 10)
        {
           
            activated = true;
            following = true;
           
        }
        if (distanceBetween > 10)
        {
            activated = false;
        }

        if (type == "Normal")
        {
            
           
           
             if (activated == false && (recolector.Ventilacion1==true || recolector.Ventilacion2==true))
            {
                
                float mindistance = Mathf.Infinity;
                generadores = GameObject.FindGameObjectsWithTag("GeneratorOn");
               
                if (generadores.Length != 0)
                {
                    
                    generatordistances = new float[generadores.Length];
                    for (int i = 0; i < generadores.Length; i++)
                    {


                        generatordistances[i] = Vector3.Distance(gameObject.transform.position, generadores[i].transform.position);
                       
                        if (generatordistances[i] < mindistance)
                        {
                          
                            mindistance = generatordistances[i];
                            if (generatordistances[i] == mindistance)
                            {

                                nav.SetDestination(generadores[i].transform.position);
                            }
                        }





                    }
                }
              
            }
            else
            {
                if (following == true)
                {
                    nav.SetDestination(player.position);
                }
            }
            

        }
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && following == true && type == "Big")
        {
            donewalls = GameObject.FindGameObjectsWithTag("Capturing");
            wallsdistances = new float [donewalls.Length];

            if (donewalls.Length != 0)
            {
                for (int i = 0; i < donewalls.Length; i++)
                {
                   

                    wallsdistances[i] = Vector3.Distance(gameObject.transform.position, donewalls[i].transform.position);
                    float min = Mathf.Infinity;
                    if (wallsdistances[i] < min)
                    {
                       
                        min = wallsdistances[i];
                        if (wallsdistances[i] == min)
                        {

                            nav.SetDestination(donewalls[i].transform.position);
                        }
                    }





                }
            }
            else
            {
                nav.SetDestination(player.position);
            }
        }
        

    }
    
}
