using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollowvel : MonoBehaviour
{

    float speed = 5f;
    float distanceclose = 1f;
    float distancefar = 20f;
    Transform player;
    Rigidbody rb;
    public float radiodis = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float magnitud = direction.magnitude;
        direction.Normalize();

        Vector3 velocity = direction * speed;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= radiodis)
        {
            if (magnitud < distancefar)
            {
                //Move the crawler
                rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);
            }
            else if (magnitud < distanceclose)
            {
                rb.velocity = new Vector3(-velocity.x, rb.velocity.y, -velocity.z);
            }
        }

        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
}
