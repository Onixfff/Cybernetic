using UnityEngine;

public abstract class AttackBehavior : MonoBehaviour
{
    [SerializeField] private float _damage;
    public float Damage => _damage;

    public abstract void PerformAttack();
}
