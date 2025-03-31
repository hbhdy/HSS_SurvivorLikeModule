using HSS;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // ----- Param -----

    public float speed;

    private List<IWeapon> rangedWeapons = new List<IWeapon>();
    private List<IWeapon> meleeWeapons = new List<IWeapon>();
    private Vector2 inputVec2;
    private Rigidbody2D rigid;

    // ----- Init -----

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // ----- Set -----

    private void OnMove(InputValue value)
    {
        inputVec2 = value.Get<Vector2>();
    }

    public void AddWeapon(WeaponType type, bool isMelee = false)
    {
        WeaponBase weapon = GameCore.RSS.GetWeapon(type).Spawn(transform);
        weapon.Init(this.transform);
        if (isMelee)
            meleeWeapons.Add(weapon);
        else
            rangedWeapons.Add(weapon);
    }

    // ----- Get -----

    public Vector2 GetInputVector2() => inputVec2;

    public Rigidbody2D GetRigid() => rigid;

    // ----- Main -----

    private void Update()
    {
        foreach (var weapon in rangedWeapons)
            weapon.Tick(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = inputVec2 * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVec);
    }

}
