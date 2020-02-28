using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generatorHealth : MonoBehaviour
{
    Image healthbar;
    [SerializeField]private float maxhealth = 200f;
    public GameObject Generator;
    float health;


    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        health = Generator.GetComponent<isActivated>().hpoints;
        healthbar.fillAmount = health / maxhealth;
    }
}
