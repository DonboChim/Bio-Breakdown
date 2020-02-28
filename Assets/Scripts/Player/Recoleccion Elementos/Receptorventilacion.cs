using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptorventilacion : MonoBehaviour
{

    Recolector rec;
    Animation ani;
    Animator anor;
    Animator an;
    Animator anor1;

    // Start is called before the first frame update
    void Awake()
    {
        rec = FindObjectOfType<Recolector>();
        anor = GetComponentInChildren<Animator>();
        ani = GetComponentInChildren<Animation>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (rec.Tubo1 == true && rec.Tubo2 == true && rec.Tubo3 == true)
            {
                an.SetBool("Abrir", true);
            }
        }
    }
}
