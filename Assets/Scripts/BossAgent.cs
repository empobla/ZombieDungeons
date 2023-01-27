/*
    Makes the boss follow the player in the scene

    Isaac Garza
*/

using UnityEngine;
using UnityEngine.AI;

class BossAgent : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent;
    Animator animator;
    bool isDead;
    float blockTime;
    public float time;
    AudioSource audioWalk;

    // Start is called before the first frame update
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        blockTime = 25f;

        audioWalk = GetComponent<AudioSource>();

        audioWalk.Play(0);
        
    }

    // Update is called once per frame
    public void Update()
    {
        time+=Time.deltaTime;
        if (time > blockTime)
        {
           time = 0;
        }
        // Follow the target only if it is within a certain range
        if (Vector3.Distance(transform.position, target.transform.position) > 3 && !isDead && time < 15f )
        { 
            agent.updatePosition = true;
            agent.SetDestination(target.transform.position);
            animator.SetBool("isWalking",true);
            animator.SetBool("isAttacking",false);
            animator.SetBool("isBlocking",false);
            audioWalk.UnPause();
            Debug.Log("started sound Walk");
        }
        else if(time < 15f)
        {
            agent.updatePosition = false;
            animator.SetBool("isWalking",false);
            animator.SetBool("isAttacking",true);
            animator.SetBool("isBlocking",false);
            audioWalk.Pause();
            Debug.Log("started sound Punch");
        }else
        {
            agent.updatePosition = false;
            animator.SetBool("isWalking",false);
            animator.SetBool("isBlocking",true);
            audioWalk.Pause();
            Debug.Log("Stops sounds ");
        }
    }

    public void EnemyDeathAnim()
    {
        isDead = true;
        agent.updatePosition = false;
        animator.SetTrigger("isDead");
        animator.SetBool("isAttacking",false);
    }

    public void EnemyBlockAnim()
    {
        animator.SetBool("isWalking",false);
        animator.SetBool("isBlocking",true);
    }

}
