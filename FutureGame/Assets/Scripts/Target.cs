
using UnityEngine;

public class Target : MonoBehaviour
{
    public float HP = 10f;

    public void TakeDamage (float amount)
    {
         HP -= amount;
        if (HP <= 0f)
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
    }
}
