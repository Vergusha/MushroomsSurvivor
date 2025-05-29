using UnityEngine;
using System.Collections.Generic; // Added for List<>

public class PlayerStats : MonoBehaviour
{
   public CharacterScriptableObject characterData;

    //Current stats
   float currentHealth;
   float currentRecovery;
    float currentMoveSpeed;
    float currentMight;
    float currentProjectileSpeed;

    //expirience and level system
    [Header("Experience/Level")] // Fixed: uppercase 'H' in Header
    public int experience = 0; // Fixed: consistent spelling of "experience"
    public int level = 1;
    public int experienceCap;


        [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }
    public List<LevelRange> levelRanges;

    void Awake()
    {
        // Initialize current stats with values from characterData
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }   

    void Start()
    {
        experienceCap = levelRanges[0].experienceCapIncrease; // Initialize experience cap from the first level range
    }
    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }
    void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level++;
            experience -= experienceCap; // Subtract the cap from experience
            int experienceCapIncrease = 0;
            foreach (LevelRange range in levelRanges)
            {
                if (level >= range.startLevel && level <= range.endLevel)
                {
                    experienceCapIncrease = range.experienceCapIncrease;
                    break;
                }
            }
            experienceCap += experienceCapIncrease; // Increase the experience cap based on the level range
        }
    }
    
}
