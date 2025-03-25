using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV2D : MonoBehaviour
{
    public Color circleColor = Color.white;

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetLayer;

    public Transform trTarget;

    [HideInInspector]
    public Collider2D[] visibleTargets;
    [HideInInspector]
    public bool isTargetInside = false;

    private void FixedUpdate()
    {
        visibleTargets = Physics2D.OverlapCircleAll((Vector2)transform.position, viewRadius, targetLayer);
        trTarget = GetNearestTr();
    }

    private Transform GetNearestTr()
    {
        Transform tr = null;
        float minDis = Mathf.Infinity;

        foreach (var target in visibleTargets)
        {
            Vector2 myPos = transform.position;
            Vector2 targetPos = target.transform.position;
            float curDis = Vector2.Distance(myPos, targetPos);

            if (curDis < minDis)
            {
                minDis = curDis;
                tr = target.transform;
            }
        }

        isTargetInside = tr != null ? true : false;
        return tr;
    }

    public void OnDrawGizmos()
    {
        // 기본 색상 설정
        Gizmos.color = circleColor;

        // 시야 반경을 원으로 표시
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        // 시야각 표시
        Vector3 leftBoundary = DirFromAngle(-viewAngle / 2, false) * viewRadius;
        Vector3 rightBoundary = DirFromAngle(viewAngle / 2, false) * viewRadius;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // 적을 감지하면 빨간색으로 시각화
        Gizmos.color = isTargetInside ? Color.red : Color.green;

        foreach (var target in visibleTargets)
            Gizmos.DrawLine(transform.position, target.transform.position);
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees -= transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}