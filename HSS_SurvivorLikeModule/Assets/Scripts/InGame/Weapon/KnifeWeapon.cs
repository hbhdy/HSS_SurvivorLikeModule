using HSS;
using UnityEngine;

public class KnifeWeapon : WeaponBase
{
    public float speed = 100;

    // ----- Param -----

    public override ProjectileType ProjectileType { get { return ProjectileType.None; } }

    // ----- Init -----

    public override void Init(Transform trPlayer)
    {
        base.Init(trPlayer);

        SetWeaponPos();
    }

    // ----- Set -----

    public override void LevelUp(float damage)
    {
        base.LevelUp(damage);

        SetWeaponPos();
    }

    public void SetWeaponPos()
    {
        for (int i = 0; i < count; i++)
        {
            Projectile knife;

            if (i < transform.childCount)
                knife = transform.GetChild(i).GetComponent<Projectile>();
            else
                knife = GameCore.RSS.GetProjectile(ProjectileType.Knife).Spawn(transform);

            // 생성시 초기화
            knife.transform.localPosition = Vector3.zero;
            knife.transform.localRotation = Quaternion.identity;

            Vector3 rotateVec = Vector3.forward * 360f * i / count;
            knife.transform.Rotate(rotateVec);
            knife.transform.Translate(knife.transform.up, Space.World);
            knife.Init(3, -1, 0, Vector2.zero);
        }
    }
    // ----- Get -----

    // ----- Main -----

    private void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelUp(damage++);
        }
    }

    protected override void Attack()
    {
    }
}