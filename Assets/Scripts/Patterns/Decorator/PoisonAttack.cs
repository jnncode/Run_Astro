using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Concrete Decorator
public class PoisonAttack : AttackDecorator {
    public PoisonAttack(IPlayerAttack attack) : base(attack) { }

    public override void Attack() {
        base.Attack();
        Debug.Log("Poison Attack!");
    }

    public override string GetDescription() {
        return attack.GetDescription() + " with Poison";
    }
}
