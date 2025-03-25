using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ----- Param -----

    public float speed;
    public Rigidbody2D target;

    private bool isLive = false;
    private Rigidbody2D rigid;

    // ----- Init -----

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(Rigidbody2D target)
    {
        isLive = true;
        this.target = target;
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
}