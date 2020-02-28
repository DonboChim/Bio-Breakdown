using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiDuctos : MonoBehaviour
{

    public Image ducto1;
    public Image ducto2;
    public Image ducto3;
    public Image ducto4;
    public Image ducto5;
    public Image ducto6;
    public Image generador1;
    public Image generador2;
    Recolector rec;

    
    // Start is called before the first frame update
    void Start()
    {
        /*rec = gameObject.GetComponent<Recolector>();*/
        /*rec = GameObject.Find("Player").GetComponent<Recolector>();*/
        rec = FindObjectOfType<Recolector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rec.Tubo1 == true)
        {
            ducto1.color = Color.white;
        }
        if (rec.Tubo1 == false)
        {
            ducto1.color = Color.black;
        }

        if (rec.Tubo2 == true)
        {
            ducto2.color = Color.white;
        }
        if (rec.Tubo2 == false)
        {
            ducto2.color = Color.black;
        }

        if (rec.Tubo3 == true)
        {
            ducto3.color = Color.white;
        }
        if (rec.Tubo3 == false)
        {
            ducto3.color = Color.black;
        }
        if (rec.Tubo4 == true)
        {
            ducto4.color = Color.white;
        }
        if (rec.Tubo4 == false)
        {
            ducto4.color = Color.black;
        }
        if (rec.Tubo5 == true)
        {
            ducto5.color = Color.white;
        }
        if (rec.Tubo5 == false)
        {
            ducto5.color = Color.black;
        }

        if (rec.Tubo6 == true)
        {
            ducto6.color = Color.white;
        }
        if (rec.Tubo6 == false)
        {
            ducto6.color = Color.black;
        }

        if (rec.Ventilacion1 == true)
        {
            generador1.color = Color.white;
        }
        if (rec.Ventilacion1 == false)
        {
            generador1.color = Color.black;
        }

        if (rec.Ventilacion2 == true)
        {
            generador2.color = Color.white;
        }
        if (rec.Ventilacion2 == false)
        {
            generador2.color = Color.black;
        }
    }
}
