using UnityEngine;

public class Target : MonoBehaviour
{
     public const float FULL_HEALTH = 50f;
     public GameEvent targetKilled;
     public float health = FULL_HEALTH;

     public void TakeDamage (float amount)
     {
          health -= amount;
          if (health <= 0f)
          {
               Die();
          }
     }

     void Die()
     {
        targetKilled.Raise();
        gameObject.SetActive(false);
        health = FULL_HEALTH;
     }
}
