using HSS;
using UnityEngine;

public interface IWeapon
{
    public void Init(Transform trPlayer);
    public void Tick(float dt);
}

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    // ----- Param -----

    public abstract ProjectileType ProjectileType { get; }

    protected FOV2D fov;
    protected Transform trPlyaer;

    protected int penetration = 1;
    protected float damage = 3;
    protected float cooldown = 1;
    protected float timer;
    protected float lifeTime = 3;

    public int count;

    // ----- Init -----

    private void Awake()
    {
        TryGetComponent<FOV2D>(out fov);
        //fov = GetComponent<FOV2D>();
    }

    public virtual void Init(Transform trPlayer)
    {
        this.trPlyaer = trPlayer;
    }

    // ----- Set -----

    public void Tick(float dt)
    {
        timer += dt;
        if(timer >= cooldown)
        {
            timer = 0;
            TryAttack();
        }
    }

    public virtual void LevelUp(float damage)
    {
        this.damage = damage;

        if (count > 0)
            count++;
    }

    // ----- Get -----

    // ----- Main -----

    private void TryAttack()
    {
        if (!fov?.trTarget)
            return;

        Attack();
    }

    protected abstract void Attack();
}