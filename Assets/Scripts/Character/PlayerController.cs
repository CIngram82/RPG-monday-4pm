using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (InteractWithCombat())
        {
            return;
        }
        if (InteractWithMovement())
        {
            return;
        }
    }

    private bool InteractWithCombat()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach(RaycastHit hit in hits)
        {
            CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
            if (target == null) continue;
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<MeleeFighter>().Attack(target);
            }
            return true;
        }
        return false;
    }

    private bool InteractWithMovement()
    {
        bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit);
        if (hasHit)
        {
            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
            return true;
        }
        return false;
    }
    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
