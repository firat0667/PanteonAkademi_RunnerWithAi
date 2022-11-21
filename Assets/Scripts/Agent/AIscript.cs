using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIscript : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent NavMesh;
    public GameObject Target;
    public GameObject Buster;
    public Animator AgentAnim;
    Vector3 StartPos;
    void Start()
    {
        StartPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        NavMesh = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMesh.SetDestination(Target.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            transform.position = StartPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Speed")
        {
            NavMesh.speed = NavMesh.speed + 3;
            Buster.SetActive(true);
            StartCoroutine(ISpeedBust());

        }
        if (other.tag == Tags.Finish_tag)
        {
            
             FinishScript finishScript =other.gameObject.GetComponent<FinishScript>();
            if (finishScript.RunnerValue<= (CheckCollisions.Instance.RunnerWinAmount))
            {
                AgentAnim.SetBool("Win", true);
                AgentAnim.SetBool("Run", false);
                NavMesh.speed = 0;
            }
            else
            {

                AgentAnim.SetBool("Lose", true);
                AgentAnim.SetBool("Run", false);
                NavMesh.speed = 0;
            }
        }
    }
    IEnumerator ISpeedBust()
    {
        yield return new WaitForSeconds(2f);
        NavMesh.speed -= 3f;
        Buster.SetActive(false);
    }
}
