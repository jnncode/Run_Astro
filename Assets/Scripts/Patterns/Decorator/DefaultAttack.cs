using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Concrete Component
public class DefaultAttack : IPlayerAttack {
    public void Attack() {
        Debug.Log("Attack");
    }

    public string GetDescription() {
        return "Attack";
    }
}
