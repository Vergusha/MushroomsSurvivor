using UnityEngine;


// <summary>
//Base script for projectile behaviour [To be placed on a prefab of a weapon that is a projectile]
// </summary>
public class ProjectileWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData; // Reference to the ScriptableObject with weapon data
    protected Vector3 direction;
    public float destroyafterSeconds;

    //Current Stats
    protected float currentDamage; // Current damage dealt by the projectile
    protected float currentSpeed; // Current speed of the projectile
    protected float currentCooldownDuration; // Current cooldown duration for the projectile
    protected int currentPierce; // Current pierce value for the projectile

    void Awake()
    {
        currentDamage = weaponData.Damage; // Initialize current damage from weapon data
        currentSpeed = weaponData.Speed; // Initialize current speed from weapon data
        currentCooldownDuration = weaponData.CooldownDuration; // Initialize current cooldown duration from weapon data
        currentPierce = weaponData.Pierce; // Initialize current pierce value from weapon data
    }
    protected virtual void Start()
    {
        Destroy(gameObject, destroyafterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0)  //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0) //down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0) //up
        {
            scale.x = scale.x * -1;
        }
        else if (dir.x > 0 && dir.y > 0) //up right
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0) //down right
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0) //down left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }
        else if (dir.x < 0 && dir.y > 0) //up left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }


        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation);

    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage); // Deal damage to the enemy
            ReducePierce(); // Reduce the pierce value
        }
    }
    void ReducePierce() //Destroy once the pierce reaches zero
    {
        currentPierce--; // Reduce the pierce value
        if (currentPierce <= 0)
        {
            Destroy(gameObject); // Destroy the projectile if pierce is zero or less
        }
    }

}
