using HSS;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed;

    private Vector2 inputVec2;
    private Rigidbody2D rigid;
    private FOV2D fov;
    private float attackSpeed;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        fov = GetComponent<FOV2D>();
    }

    public Vector2 GetInputVector2() => inputVec2;

    public Rigidbody2D GetRigid() => rigid;

    private void OnMove(InputValue value)
    {
        inputVec2 = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = inputVec2 * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        attackSpeed += Time.fixedDeltaTime;

        if (attackSpeed >= 0.2f)
        {
            attackSpeed = 0;
            Fire();
        }
    }

    private void Fire()
    {
        if (!fov.trTarget)
            return;

        Vector3 targetPos = fov.trTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        Projectile projectile = GameCore.Instance.projectilePrefab.Spawn(GameCore.Instance.trEnemySpawnParent, transform.position);
        projectile.Init(0, 1, 0, dir);
    }
}
