using HSS;
using UnityEngine;

public class AuraWeapon : WeaponBase
{
    // ----- Param -----

    public override ProjectileType ProjectileType { get { return ProjectileType.None; } }

    // ----- Init -----

    // ----- Set -----

    // ----- Get -----

    // ----- Main -----

    protected override void Attack()
    {
        foreach(var tr in fov.GetAllDetectedTargets())
        {
            var enemy = tr.GetComponent<Enemy>();
            if (enemy != null)
                enemy.Hit(damage);
        }
    }
}