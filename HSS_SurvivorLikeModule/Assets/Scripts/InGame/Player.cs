using HSS;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // ----- Param -----

    public float speed;

    private List<IWeapon> weapons = new List<IWeapon>();
    private Vector2 inputVec2;
    private Rigidbody2D rigid;
    private FOV2D fov;
    private float attackSpeed;

    // ----- Init -----

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        fov = GetComponent<FOV2D>();
    }

    // ----- Set -----

    private void OnMove(InputValue value)
    {
        inputVec2 = value.Get<Vector2>();
    }

    // ----- Get -----

    public Vector2 GetInputVector2() => inputVec2;

    public Rigidbody2D GetRigid() => rigid;

    // ----- Main -----

    private void Update()
    {
        foreach (var weapon in weapons)
            weapon.Tick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = inputVec2 * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }

    // 해당 로직은 무기로 분할 예정

    private void Fire()
    {
        if (!fov.trTarget)
            return;

        Vector3 targetPos = fov.trTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        Projectile projectile = GameCore.Instance.projectilePrefab.Spawn(GameCore.Instance.trEnemySpawnParent, transform.position);
        projectile.Init(5, 1, 3, dir);
    }
}
