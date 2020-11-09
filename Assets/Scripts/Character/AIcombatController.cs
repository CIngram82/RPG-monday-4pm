using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;
using RPG.Movement;

namespace RPG.Control
{
    public class AIcombatController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        private GameObject target;
        private MeleeFighter myFighterScript;
        private Health myHealth;
        private Mover myMover;

        // Start is called before the first frame update
        void Start()
        {
            target = GameObject.FindGameObjectWithTag("Player");
            myFighterScript = GetComponent<MeleeFighter>();
            myHealth = GetComponent<Health>();
            myMover = GetComponent<Mover>();
        }

        // Update is called once per frame
        void Update()
        {
            if (myHealth.IsDead()) return;
            float dist = Vector3.Distance(target.transform.position, transform.position);
            print(myFighterScript.CanAttack(target));
            if (dist <= chaseDistance && myFighterScript.CanAttack(target))
            {
                myFighterScript.Attack(target);
            }
            else
            {
                
            }
        }
    }
}