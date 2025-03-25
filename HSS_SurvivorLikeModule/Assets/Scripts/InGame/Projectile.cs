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
        rigid = GetComponent<Rigidbody2D>();
        trail = GetComponent<TrailRenderer>();
    }

    public void Init(float damage, int per, float time, Vector2 dir)
    {
        //this.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        this.damage = damage;
        this.per = per;
        this.time = time;

        // 관통력 처리
        if (per > -1)
            rigid.linearVelocity = dir * 10f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1)
            return;

        per--;

        if (per <= 0)
        {
            trail.Clear();
            rigid.linearVelocity = Vector2.zero;
            gameObject.Recycle();
        }
    }

    // ----- Set -----

    // ----- Get -----

    // ----- Main -----

}