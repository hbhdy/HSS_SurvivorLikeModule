using System;
using UnityEngine;

[Serializable]
public class PlayerStatMetaData
{
    public int ID;

    // ----- 공격 -----

    [Header("공격력")]
    public float Atk;

    [Header("공격 속도")]
    public float AtkSpeed;

    [Header("치명타 확률")]
    public float CriChance;

    [Header("치명타 피해량")]
    public float CriDamage;

    [Header("방어 관통력")]
    public float ArmorPenetration;

    // ----- 방어 -----

    [Header("최대 체력")]
    public float Hp;

    [Header("체력 재생")]
    public float HpRegen;

    [Header("방어력")]
    public float Armor;

    [Header("피해 감소")]
    public float DamageReduction;

    // ----- 이동속도 -----

    [Header("이동속도")]
    public float MoveSpeed;

    // ----- 투사체 -----

    [Header("추가 투사체")]
    public float AddProjectile;

    [Header("투사체 관통력")]
    public float ProjectilePenetration;

    [Header("투사체 지속시간")]
    public float ProjectileLifeTime;

    [Header("투사체 속도")]
    public float ProjectileSpeed;

    [Header("투사체 크기")]
    public float ProjectileSize;

    // ----- 범위 -----

    [Header("무기의 범위 (비투사체)")]
    public float WeaponRange;

    // ----- 유틸리티 -----

    [Header("경험치 획득 거리")]
    public float XpGetRange;
}