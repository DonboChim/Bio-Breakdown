using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public float radiodis = 10f;
    Transform target;
    Animator an;
    NavMeshAgent nav;


    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= radiodis)
        {
            nav.SetDestination(target.position);
            Facetarget();
        }

        if (distance <= nav.stoppingDistance)
        {
            Atacar();
            Facetarget();

        }

        void Facetarget()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * 5f);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, radiodis);
        }

        void Atacar()
        {
            Debug.Log("ataque");
        }
    }
}
