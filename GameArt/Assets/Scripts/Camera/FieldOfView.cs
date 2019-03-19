using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTarget = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetWithDelay", .2f);
    }

    IEnumerator FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTarget();
        }
    }

    void FindVisibleTarget()
    {
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i=0; i < targetInViewRadius.Length; i++)
        {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                //Things to do when target is spotted
                if(!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    Debug.Log("target spotted");
                    visibleTarget.Add(target);
                }
            }
        }
    }
    
    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    { 
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
