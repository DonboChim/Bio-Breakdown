using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    [SerializeField] private float timer;
    public Text textbox;
    Recolector rec;
    public ParticleSystem system;
    public int numeroGeneradores;

    // Start is called before the first frame update
    void Start()
    {
        textbox.text = timer.ToString();
        rec = GetComponent<Recolector>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textbox.text = Mathf.Round(timer).ToString();
       

        if(timer <= 0 )
        {
            GameObject[] generadores =GameObject.FindGameObjectsWithTag("GeneratorOn");
            if(generadores.Length == numeroGeneradores)
            {
                SceneManager.LoadScene("Victoria");
                Debug.Log("Ganaste");
            }
            if (generadores.Length != numeroGeneradores)
            {
                SceneManager.LoadScene("Derrota");
                Debug.Log("Perdiste por generadores");
            }

            timer = 0;
        }
    }

    
}
