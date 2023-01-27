/*
    Makes the enemy follow the player in the scene

    Emilio Popovits
*/

using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    public GameObject target;
    
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the target only if it is within a certain range
        if (Vector3.Distance(transform.position, target.transform.position) < 20)
        { 
            agent.destination = target.transform.position;
        }
        else
        {
            agent.destination = transform.position;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject == target)
        {
            // Make the agent stop
            Debug.Log("DED");
            agent.velocity = Vector3.zero;
            agent.speed = 0;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject == target)
        {
            agent.speed = 3.5f;
        }
    }
}
