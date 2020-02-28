using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolector : MonoBehaviour
{

    [SerializeField]private bool tubo1 = false;
    [SerializeField] private bool tubo2 = false;
    [SerializeField] private bool tubo3 = false;

    [SerializeField] private bool tubo4 = false;
    [SerializeField] private bool tubo5 = false;
    [SerializeField] private bool tubo6 = false;

    [SerializeField] private bool ventilacion1 = false;
    [SerializeField] private bool ventilacion2 = false;


    public bool Ventilacion1
    {
        get { return ventilacion1; }
        set { ventilacion1 = value; }
    }
    public bool Ventilacion2
    {
        get { return ventilacion2; }
        set { ventilacion2 = value; }
    }
    public bool Tubo1
    {
        get {return tubo1;}
        set {tubo1 = value;}
    }
    public bool Tubo2
    {
        get { return tubo2; }
        set { tubo2 = value; }
    }
    public bool Tubo3
    {
        get { return tubo3; }
        set { tubo3 = value; }
    }
    public bool Tubo4
    {
        get { return tubo4; }
        set { tubo4 = value; }
    }
    public bool Tubo5
    {
        get { return tubo5; }
        set { tubo5 = value; }
    }
    public bool Tubo6
    {
        get { return tubo6; }
        set { tubo6 = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(tubo1 && tubo2 && tubo3)
        {
            ventilacion1 = true;
        }
        if (tubo4 && tubo5 && tubo6)
        {
            ventilacion2 = true;
        }
    }

    private void OnTriggerEnter(Collider colider)
    {
        if (colider.CompareTag("Tubo1"))
        {
            tubo1 = true;
        }
        if (colider.CompareTag("Tubo2"))
        {
            tubo2 = true;
        }
        if (colider.CompareTag("Tubo3"))
        {
            tubo3 = true;
        }
        if (colider.CompareTag("Tubo4"))
        {
            tubo4 = true;
        }
        if (colider.CompareTag("Tubo5"))
        {
            tubo5 = true;
        }
        if (colider.CompareTag("Tubo6"))
        {
            tubo6 = true;
        }
        /*if (colider.CompareTag("Tubo7"))
        {
            tubo7 = true;
        }
        if (colider.CompareTag("Tubo8"))
        {
            tubo8 = true;
        }
        if (colider.CompareTag("Tubo9"))
        {
            tubo9 = true;
        }*/

       
    }
}

