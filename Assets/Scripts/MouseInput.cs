using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(AttackBehavior))]
public class MouseInput : MonoBehaviour
{
    private AttackBehavior _attacker;

    private void Start()
    {
        _attacker = GetComponent<AttackBehavior>();
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown((int)MouseButton.Left)) {
            _attacker.PerformAttack();
        }
    }
}
