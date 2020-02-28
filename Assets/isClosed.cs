using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isClosed : MonoBehaviour
{
    Vector3 origin;
    [SerializeField] float thickness;
    Vector3 directionRight;
    Vector3 directionForward;
    Vector3 directionLeft;
    Vector3 directionDown;
    bool enemietrue;
    bool innertrue;
    RaycastHit raycastDerecha1;
    RaycastHit raycastIzquierda1;
    RaycastHit raycastArriba1;
    RaycastHit raycastAbajo1;
    RaycastHit enemyRaycast1;
    RaycastHit[] raycastDerecha;
    RaycastHit[] raycastIzquierda;
    RaycastHit[] raycastArriba;
    RaycastHit[] raycastAbajo;
    RaycastHit[] enemyRaycast;
    float distancebetweenright;
    float distancebetweenleft;
    float distancebetweenup;
    float distancebetweendown;

    CreateWalls CreateWalls;
    int layerMask1;
    int layerMask2;
    // Start is called before the first frame update
    void Start()
    {
        layerMask1 =LayerMask.GetMask("enemies");
        layerMask2 = LayerMask.GetMask("walls");
        CreateWalls = GameObject.Find("Player1").GetComponent<CreateWalls>();

    }

    // Update is called once per frame
    void Update()
    {
        //hay que hacer 4 raycast que nos den la distancia de la primer pared golpeada, segun su direccion, para poder poner esa distancia como la distancia maxima de los otros 4 raycast que detectan enemigos y paredes a la vez
        origin = gameObject.transform.position;
        directionRight = gameObject.transform.right;
        directionForward = gameObject.transform.forward;
        directionLeft = gameObject.transform.right * -1;
        directionDown = gameObject.transform.forward * -1;
        //raycast unitario derecha
        if(Physics.Raycast(origin,directionRight,out raycastDerecha1, Mathf.Infinity, layerMask1))
        {
            distancebetweenright = raycastDerecha1.distance;
            
        }
        // raycast unitario izquierda
        if (Physics.Raycast(origin, directionLeft, out raycastIzquierda1, Mathf.Infinity, layerMask1))
        {
            distancebetweenleft= raycastIzquierda1.distance;

        }
        // raycast unitario arriba
        if (Physics.Raycast(origin, directionForward, out raycastArriba1, Mathf.Infinity, layerMask1))
        {
            distancebetweenup = raycastArriba1.distance;

        }
        // raycast unitario abajo
        if (Physics.Raycast(origin, directionDown, out raycastAbajo1, Mathf.Infinity, layerMask1))
        {
            distancebetweendown = raycastAbajo1.distance;

        }


        //raycast doble derecha
        raycastDerecha = Physics.RaycastAll(origin, directionRight, distancebetweenright, layerMask1);

        for (int i = 0; i < raycastDerecha.Length; ++i)
        {
            if (gameObject.tag == "inner")
            {
                if (raycastDerecha[i].collider.gameObject.tag == "Done")
                {
                    innertrue = true;
                }
                if (raycastDerecha[i].collider.gameObject.tag == "Enemy")
                {
                    enemietrue = true;
                }


                if (innertrue && enemietrue)
                {

                    if (raycastDerecha[i].collider.gameObject.tag == "Done")
                    {
                        raycastDerecha[i].collider.gameObject.tag = "Capturing";
                    }

                    Debug.DrawRay(origin, directionRight * distancebetweenright, Color.yellow);
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine("Destruir");
                }
            }

        }
        //raycast doble izquierda
        raycastIzquierda = Physics.RaycastAll(origin, directionLeft, distancebetweenleft, layerMask1);

        for (int i = 0; i < raycastIzquierda.Length; ++i)
        {
            if (gameObject.tag == "inner")
            {
                if (raycastIzquierda[i].collider.gameObject.tag == "Done")
                {
                    innertrue = true;
                }
                if (raycastIzquierda[i].collider.gameObject.tag == "Enemy")
                {
                    enemietrue = true;
                }


                if (innertrue && enemietrue)
                {

                    if (raycastIzquierda[i].collider.gameObject.tag == "Done")
                    {
                        raycastIzquierda[i].collider.gameObject.tag = "Capturing";
                    }

                    Debug.DrawRay(origin, directionLeft* distancebetweenleft, Color.blue);
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine("Destruir");
                }
            }

        }
        //raycast doble arriba
        raycastArriba= Physics.RaycastAll(origin, directionForward, distancebetweenup, layerMask1);

        for (int i = 0; i < raycastArriba.Length; ++i)
        {
            if (gameObject.tag == "inner")
            {
                if (raycastArriba[i].collider.gameObject.tag == "Done")
                {
                    innertrue = true;
                }
                if (raycastArriba[i].collider.gameObject.tag == "Enemy")
                {
                    enemietrue = true;
                }


                if (innertrue && enemietrue)
                {

                    if (raycastArriba[i].collider.gameObject.tag == "Done")
                    {
                        raycastArriba[i].collider.gameObject.tag = "Capturing";
                    }

                    Debug.DrawRay(origin, directionForward * distancebetweenup, Color.blue);
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine("Destruir");
                }
            }

        }
        //raycast doble abajo
        raycastAbajo = Physics.RaycastAll(origin, directionDown, distancebetweendown, layerMask1);

        for (int i = 0; i < raycastAbajo.Length; ++i)
        {
            if (gameObject.tag == "inner")
            {
                if (raycastAbajo[i].collider.gameObject.tag == "Done")
                {
                    innertrue = true;
                }
                if (raycastAbajo[i].collider.gameObject.tag == "Enemy")
                {
                    enemietrue = true;
                }


                if (innertrue && enemietrue)
                {

                    if (raycastAbajo[i].collider.gameObject.tag == "Done")
                    {
                        raycastAbajo[i].collider.gameObject.tag = "Capturing";
                    }

                    Debug.DrawRay(origin, directionDown * distancebetweendown, Color.blue);
                    Destroy(gameObject);
                }
                else
                {
                    StartCoroutine("Destruir");
                }
            }

        }
       







    }
    IEnumerator Destruir()
    {

        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);


    }
}