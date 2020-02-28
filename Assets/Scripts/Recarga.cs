using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recarga : MonoBehaviour
{

    CreateWalls createwall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            CreateWalls.Carga = 100f;
            Destroy(gameObject);
        }
    }
}
