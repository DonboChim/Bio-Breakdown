using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickering : MonoBehaviour
{
    Light luz;
    public bool up = true;
    float timer;
    [SerializeField]
    float timeToReachTarget;
    // Start is called before the first frame update
    void Start()
    {
        
        luz = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime/timeToReachTarget;
       
        
        if (up == true)
        {
            luz.intensity = Mathf.Lerp(0, 1.21f, timer);
            if (luz.intensity >=1.21f)
            {
                timer = 0;
                up = false;


            }
        }

        if (up == false)
        {
            luz.intensity = Mathf.Lerp(1.21f, 0, timer);
            if (luz.intensity == 0)
            {
                up = true;
                timer = 0;

            }
        }

    }
}
