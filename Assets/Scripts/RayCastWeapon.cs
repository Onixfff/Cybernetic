using UnityEngine;
using UnityEngine.Events;

public class RayCastWeapon : AttackBehavior
{
    [Header("Ray")]
    [SerializeField, Min(0)] private float _fireDistance;
    [SerializeField, Min(1)] private int _fireCount;
    [SerializeField] private LayerMask _layers;
    [Header("GunValues")]
    [SerializeField, Min(0)] private float _fireSpeed;
    [Header("Spread")]
    [SerializeField] private bool _useSpread;
    [SerializeField] private float _spreadCoefficient;

    private float _currentFireTime;

    public UnityEvent<RaycastHit> Fire;
    public override void PerformAttack()
    {
        for(int i = 0; i< _fireCount; i++)
        {
            Attack();
        }
    }
    private void Attack()
    {
        var direction = _useSpread ? transform.forward + CalculateSpread() : transform.forward;
        if(Physics.Raycast(transform.position, direction,out RaycastHit hitInfo,_fireDistance,_layers))
        {
            if(hitInfo.collider.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(Damage);
            }
            Fire?.Invoke(hitInfo);
        }
    }
    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
            x = Random.Range(-_spreadCoefficient, _spreadCoefficient),
            y = Random.Range(-_spreadCoefficient, _spreadCoefficient),
            z = Random.Range(-_spreadCoefficient, _spreadCoefficient)
        };
    }
}
