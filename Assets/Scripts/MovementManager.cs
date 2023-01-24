using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//URL : https://levelup.gitconnected.com/tip-of-the-day-create-a-point-click-system-in-unity-3d-8de30efee5e2
public class MovementManager : MonoBehaviour
{
    NavMeshAgent _navAgent;

    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            print(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, _navAgent.areaMask))
            {
                _navAgent.SetDestination(hit.point);
            }
        }
    }

}
