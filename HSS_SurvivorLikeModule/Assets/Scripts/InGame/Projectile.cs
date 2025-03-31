using HSS;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // ----- Param -----

    public float damage;
    public float time;
    public int per;

    private Rigidbody2D rigid;
    private TrailRenderer trail;

    // ----- Init -----

    private void Awake()
    {
        TryGetComponent<Rigidbody2D>(out rigid);
        trail = GetComponentInChildren<TrailRenderer>();
    }

    public void Init(float damage, int per, float time, Vector2 dir)
    {
        this.damage = damage;
        this.per = per;
        this.time = time;

        // 包烹仿 贸府, -1篮 公茄 包烹
        if (per > -1)
        {
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
            rigid.linearVelocity = dir * 10f;
        }
    }

    private void OnEnable()
    {
        if (this != null)
            GameCore.PROJECTILE.AddProjectile(this);
    }

    private void OnDisable()
    {
        if (this != null)
            GameCore.PROJECTILE.RemoveProjectile(this);
    }

    // ----- Set -----

    public void SetRecycle()
    {
        trail.Clear();
        rigid.linearVelocity = Vector2.zero;
        gameObject.Recycle();
    }

    // ----- Get -----

    public bool IsLifeTimeCheck()
    {
        time -= Time.deltaTime;
        return time <= 0f;
    }

    // ----- Main -----

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1)
            return;

        per--;

        if (per <= 0)
            SetRecycle();
    }
}