using HSS;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ProjectileManager : BaseManager
{
    // ----- Param -----

    public List<Projectile> projectileLists = new();

    // ----- Init -----

    public override IEnumerator Co_Init()
    {
        return base.Co_Init();
    }

    public override void Init()
    {
        base.Init();
    }

    // ----- Set -----

    public void AddProjectile(Projectile p) => projectileLists.Add(p);

    public void RemoveProjectile(Projectile p) => projectileLists.Remove(p);

    // ----- Get -----

    // ----- Main -----

    private void Update()
    {
        if (!isReady)
            return;

        for (int i = projectileLists.Count - 1; i >= 0; i--)
        {
            var p = projectileLists[i];
            if (p.IsLifeTimeCheck() && p.per != -1)
                p.SetRecycle();
        }
    }
}