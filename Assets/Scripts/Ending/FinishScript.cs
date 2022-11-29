using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
   
    public int RunnerValue;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        RunnerValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==Tags.Runner_tag)
        {
            RunnerValue++; 
        }
        if (other.gameObject.tag == Tags.Ghost_tag)
        {
            Debug.Log(timer);
        }
    }
}
