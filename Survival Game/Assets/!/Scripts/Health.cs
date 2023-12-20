using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public int MaxHP { get; set; }
    [field: SerializeField] public int CurrentHP { get; set; }

    void Update()
    {
        Die();
    }

    public virtual void TakeDamage(int damage)
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
