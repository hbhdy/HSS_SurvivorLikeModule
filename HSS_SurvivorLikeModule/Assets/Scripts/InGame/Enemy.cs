using ExcelDataReader.Core;
using HSS;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ----- Param -----

    public float speed;
    public float hp;

    [HideInInspector]
    public Rigidbody2D target;

    private bool isLive = false;
    private Rigidbody2D rigid;
    private Collider2D coll;

    // ----- Init -----

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    public void Init(Rigidbody2D target, float hp)
    {
        this.target = target;
        this.hp = hp;

        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
    }

    // ----- Set -----

    // ----- Get -----

    // ----- Main -----

    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = (target.position - rigid.position).normalized;
        Vector2 toVec = dirVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + toVec);
        rigid.linearVelocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Projectile"))
            return;

        Hit(collision.GetComponent<Projectile>().damage);
    }

    public void Hit(float damage)
    {
        if (!isLive)
            return;

        hp -= damage;

        if (hp <= 0)
            Recycle();
    }

    private void Recycle()
    {
        isLive = false;
        coll.enabled = false;
        rigid.simulated = false;
        gameObject.Recycle();
    }
}