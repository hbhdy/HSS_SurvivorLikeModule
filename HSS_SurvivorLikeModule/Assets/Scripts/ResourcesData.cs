using HSS;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesData", menuName = "ScriptableObjects/ResourcesData", order = 1)]
public class ResourcesData : ScriptableObject
{
    // ----- Param -----

    [Header("----- Prefab -----")]
    public List<GameObject> Projectiles = new();
    public List<GameObject> Weapons = new();

    private Dictionary<WeaponType, IWeapon> dicWeapons = new();
    private Dictionary<ProjectileType, Projectile> dicProjectiles = new();

    // ----- Init -----

    public void Init()
    {
        // ���� ���ں��ٴ� �����ϰ� Enum�� ������ �̸� �� ó�� ( �޸� ���� ����!? )
        foreach (WeaponType type in Enum.GetValues(typeof(WeaponType)))
        {
            string typeName = type.ToString();
            var prefab = Weapons.Find(x => x.name.StartsWith(typeName + "Weapon"));
            if (prefab != null)
                dicWeapons[type] = prefab.GetComponent<IWeapon>();
        }

        foreach (ProjectileType type in Enum.GetValues(typeof(ProjectileType)))
        {
            string typeName = type.ToString();
            var prefab = Projectiles.Find(x => x.name.StartsWith(typeName));
            if (prefab != null)
                dicProjectiles[type] = prefab.GetComponent<Projectile>();
        }
    }

    // ----- Set -----

    // ----- Get -----

    public IWeapon GetWeapon(WeaponType type) => dicWeapons[type];

    public Projectile GetProjectile(ProjectileType type) => dicProjectiles[type];

    // ----- Main -----
}