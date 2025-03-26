using Mono.Cecil;
using UnityEngine;

public interface IWeapon
{
    public void Init(Transform trPlayer);
    public void Tick(float dt);
}

public abstract class WeaponBase : MonoBehaviour, IWeapon
{
    // ----- Param -----

    protected Transform trPlyaer;
    protected float cooldown;
    protected float timer;

    // ----- Init -----

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
            Attack();
        }
    }

    // ----- Get -----

    // ----- Main -----

    protected abstract void Attack();


}