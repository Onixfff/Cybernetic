using UnityEngine;

public class TestDamagable : MonoBehaviour, IDamagable
{
    [SerializeField] private float _resetColorTime;

    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
    }
}
