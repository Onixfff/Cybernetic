using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(RayCastWeapon))]
public class HitEffectsSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem _hitParticlePrefab;

    private RayCastWeapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<RayCastWeapon>();
        _weapon.Fire.AddListener(CreateEffect);
    }

    private void CreateEffect(RaycastHit hitInfo)
    {
        var spawnPosition = hitInfo.point;
        var rotation = Quaternion.LookRotation(hitInfo.normal);
        Instantiate(_hitParticlePrefab, spawnPosition, rotation);
    }
}
