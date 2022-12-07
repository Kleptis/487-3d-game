using UnityEngine;

public class Target : MonoBehaviour
{
     public GameEvent targetKilled;
     public float health = 50f;

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
          Destroy(gameObject);
     }
}
