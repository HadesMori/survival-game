using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float MaxHP { get; set; }
    [field: SerializeField] public float CurrentHP { get; set; }

    void Update()
    {
        Die();
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHP -= damage;
    }

    protected virtual void Die()
    {
        if(CurrentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
