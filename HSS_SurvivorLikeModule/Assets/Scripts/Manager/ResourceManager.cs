using HSS;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : BaseManager
{
    // ----- Param -----

    public ResourcesData resources;

    // ----- Init -----

    public override IEnumerator Co_Init()
    {
        resources.Init();
        return base.Co_Init();
    }

    public override void Init()
    {
        base.Init();
    }

    // ----- Set -----

    // ----- Get -----

    public IWeapon GetWeapon(WeaponType type) => resources.GetWeapon(type);

    public Projectile GetProjectile(ProjectileType type) => resources.GetProjectile(type);

    // ----- Main -----

}