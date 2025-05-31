using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData; // Ссылка на ScriptableObject с данными оружия
    public float destroyAfterSeconds;

    // Текущие характеристики
    protected float currentDamage; // Текущий урон, наносимый оружием
    protected float currentSpeed; // Текущая скорость оружия
    protected float currentCooldownDuration; // Текущая продолжительность перезарядки оружия
    protected int currentPierce; // Текущее значение пробития оружия

    void Awake()
    {
        currentDamage = weaponData.Damage; // Инициализация текущего урона из данных оружия
        currentSpeed = weaponData.Speed; // Инициализация текущей скорости из данных оружия
        currentCooldownDuration = weaponData.CooldownDuration; // Инициализация текущей продолжительности перезарядки из данных оружия
        currentPierce = weaponData.Pierce; // Инициализация текущего значения пробития из данных оружия
    }
    //     protected virtual void Start()
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); // Deal damage to the enemy
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage); // Deal damage to the breakable prop
            }
        }
    }

}
