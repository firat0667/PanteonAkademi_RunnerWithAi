using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaningSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public float Distance;
    public GameObject Target;
    public int Rank;
    void CalculateDistance()
    {
        Distance = Vector3.Distance(transform.position,Target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDistance();
    }
}
