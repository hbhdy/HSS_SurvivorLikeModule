using HSS;
using UnityEngine;

public class GunWeapon : WeaponBase
{
    // ----- Param -----

    public override ProjectileType ProjectileType { get { return ProjectileType.Bullet; } }

    // ----- Init -----

    // ----- Set -----

    // ----- Get -----

    // ----- Main -----

    protected override void Attack()
    {
        Vector3 targetPos = fov.trTarget.position;
        Vector3 dir = (targetPos - transform.position).normalized;

        Projectile projectile = GameCore.RSS.GetProjectile(ProjectileType).Spawn(GameCore.Instance.trEnemySpawnParent, transform.position);
        projectile.Init(damage, penetration, lifeTime, dir);
    }
}