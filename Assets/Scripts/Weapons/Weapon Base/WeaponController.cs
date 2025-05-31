using UnityEngine;


// <summary>
//Скрипт для управления оружием
// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData; // Ссылка на ScriptableObject с данными оружия
    float currentCooldown;

    protected PlayerMovement pm;
    protected virtual void Start()
    {
        currentCooldown = weaponData.CooldownDuration; // Инициализация текущего времени перезарядки
        pm = FindAnyObjectByType<PlayerMovement>(); // Поиск объекта PlayerMovement в сцене
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime; // Уменьшение времени перезарядки
        if (currentCooldown <= 0f)
        {
            Attack(); // Если время перезарядки меньше нуля, вызываем атаку
        }
    }

    protected virtual void Attack()
    {
        // Сброс времени перезарядки
        currentCooldown = weaponData.CooldownDuration;

    }
}
