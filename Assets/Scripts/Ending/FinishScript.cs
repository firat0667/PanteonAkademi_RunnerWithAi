using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
   
    public int RunnerValue;
    // Start is called before the first frame update
    void Start()
    {
        RunnerValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==Tags.Player_tag|| other.gameObject.tag == Tags.Agent_tag)
        {
            RunnerValue++; 
        }
    }
}
