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

    protected int penetration;
    protected float damage;
    protected float cooldown;
    protected float timer;
    protected float lifeTime;

    // ----- Init -----

    private void Awake()
    {
        fov = GetComponent<FOV2D>();
    }

    public void Init(Transform trPlayer)
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

    // ----- Get -----

    // ----- Main -----

    private void TryAttack()
    {
        if (!fov.trTarget)
            return;

        Attack();
    }

    protected abstract void Attack();
}