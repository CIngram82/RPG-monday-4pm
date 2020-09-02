using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeFighter : MonoBehaviour
{
    [SerializeField] private float weaponRange = 2f;
    Transform target;


    // Update is called once per frame
    void Update()
    {
        bool inRange = (Vector3.Distance(transform.position, target.position) < weaponRange);

        if (target != null && !inRange)
        {
            GetComponent<Mover>().MoveTo(target.position);
        }
    }

    public void Attack(CombatTarget combatTarget)
    {
        Debug.Log("Attacking :" + combatTarget.name);
        target = combatTarget.transform;
        
    }
}
