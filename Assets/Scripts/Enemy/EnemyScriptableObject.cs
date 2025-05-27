using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject

{
    //Base stats for the enemy
    [SerializeField]
    float moveSpeed; // Скорость движения врага
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    [SerializeField]
    float maxHealth; // Максимальное здоровье врага
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    [SerializeField]
    float damage; // Урон, наносимый врагом
    public float Damage { get => damage; private set => damage = value; }
}
