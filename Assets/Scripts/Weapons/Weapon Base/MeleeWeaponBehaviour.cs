using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData; // Ссылка на ScriptableObject с данными оружия
    public float destroyAfterSeconds;
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }

}
