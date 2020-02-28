using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptorventilacion2 : MonoBehaviour
{

    Recolector rec;
    Animation ani;
    Animator anor;
    Animator an;


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
        if(collision.gameObject.CompareTag("Player"))
        {
            if (rec.Tubo4 == true && rec.Tubo5 == true && rec.Tubo6 == true)
            {
                an.SetBool("Abrir3", true);
            }
        }
    }
}
