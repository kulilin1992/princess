using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadiu = 0.1f;

    [SerializeField] LayerMask groundLayer;
    Collider[] colliders = new Collider[1];
    // public bool IsGrounded
    // {
    //     get
    //     {
    //         return Physics.OverlapSphereNonAlloc(transform.position, detectionRadiu, colliders, groundLayer) > 0;
    //     }
    // }
    public bool IsGrounded => Physics.OverlapSphereNonAlloc(transform.position, detectionRadiu, colliders, groundLayer) > 0;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadiu);
    }
}
