using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isActivated : MonoBehaviour
{
    public bool activated;
    public string generatornumber;
    Recolector player;
    public float hpoints;
    public float initialhp;
    [SerializeField]GameObject tubo1;
    [SerializeField] GameObject tubo2;
    [SerializeField] GameObject tubo3;
    [SerializeField] GameObject tubo4;
    [SerializeField] GameObject tubo5;
    [SerializeField] GameObject tubo6;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Recolector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpoints <= 0)
        {
            activated = false;
            if (generatornumber == "1")
            {
                player.Tubo1 = false;
                player.Tubo2 = false;
                player.Tubo3 = false;
                player.Ventilacion1 = false;
                tubo1.SetActive(true);
                tubo2.SetActive(true);
                tubo3.SetActive(true);
                hpoints = initialhp;
            }
            if (generatornumber == "2")
            {
                player.Tubo4 = false;
                player.Tubo5 = false;
                player.Tubo6 = false;
                player.Ventilacion2 = false;
                tubo4.SetActive(true);
                tubo5.SetActive(true);
                tubo6.SetActive(true);

                hpoints = initialhp;
            }

        }
        
        if(generatornumber == "1" && player.Ventilacion1 == true)
        {
            activated = true;
        }
       
        if(generatornumber =="2" && player.Ventilacion2 == true)
        {
            activated = true;
        }
        
        if(activated == true)
        {
            gameObject.tag = "GeneratorOn";
        }
        else if( activated ==false)
        {
            gameObject.tag = "Generator";
        }
    }
    public void TakeDamage(float damage)
    {
        if(activated == true)
        {
            hpoints -= damage;
        }
        
    }
}
