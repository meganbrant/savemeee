using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class nav : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
      

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position)>4){
            agent.destination = target.position;
        }
          else{
              agent.destination = target.position;
          }

    }
}
