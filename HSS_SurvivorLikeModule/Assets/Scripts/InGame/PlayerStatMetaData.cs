using System;
using UnityEngine;

[Serializable]
public class PlayerStatMetaData
{
    public int ID;

    // ----- ���� -----

    [Header("���ݷ�")]
    public float Atk;

    [Header("���� �ӵ�")]
    public float AtkSpeed;

    [Header("ġ��Ÿ Ȯ��")]
    public float CriChance;

    [Header("ġ��Ÿ ���ط�")]
    public float CriDamage;

    [Header("��� �����")]
    public float ArmorPenetration;

    // ----- ��� -----

    [Header("�ִ� ü��")]
    public float Hp;

    [Header("ü�� ���")]
    public float HpRegen;

    [Header("����")]
    public float Armor;

    [Header("���� ����")]
    public float DamageReduction;

    // ----- �̵��ӵ� -----

    [Header("�̵��ӵ�")]
    public float MoveSpeed;

    // ----- ����ü -----

    [Header("�߰� ����ü")]
    public float AddProjectile;

    [Header("����ü �����")]
    public float ProjectilePenetration;

    [Header("����ü ���ӽð�")]
    public float ProjectileLifeTime;

    [Header("����ü �ӵ�")]
    public float ProjectileSpeed;

    [Header("����ü ũ��")]
    public float ProjectileSize;

    // ----- ���� -----

    [Header("������ ���� (������ü)")]
    public float WeaponRange;

    // ----- ��ƿ��Ƽ -----

    [Header("����ġ ȹ�� �Ÿ�")]
    public float XpGetRange;
}