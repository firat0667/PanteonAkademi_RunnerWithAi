using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform CameraTarget;
    public float Speed;
    public Vector3 Dist;
    public Transform LookTarget;
    public float ZposDistancePlayer = 5;
    private void LateUpdate()
    {

        Vector3 Dposition = CameraTarget.position + Dist;
        Vector3 Spos = Vector3.Lerp(transform.position, Dposition, Speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, LookTarget.transform.position.z - ZposDistancePlayer);
        // transform.LookAt(LookTarget.position);
    }
}
