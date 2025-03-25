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
        // �⺻ ���� ����
        Gizmos.color = circleColor;

        // �þ� �ݰ��� ������ ǥ��
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        // �þ߰� ǥ��
        Vector3 leftBoundary = DirFromAngle(-viewAngle / 2, false) * viewRadius;
        Vector3 rightBoundary = DirFromAngle(viewAngle / 2, false) * viewRadius;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // ���� �����ϸ� ���������� �ð�ȭ
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