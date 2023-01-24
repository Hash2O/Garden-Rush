using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//URL : https://levelup.gitconnected.com/tip-of-the-day-create-a-point-click-system-in-unity-3d-8de30efee5e2

//Permet d'associer automatiquement un type de component avec le script 
//quand il est plac� sur un objet
[RequireComponent(typeof(NavMeshAgent))]
public class MovementManager : MonoBehaviour
{
    private NavMeshAgent agent;

    private Vector3 destination;

    private List<Vector3> destinations = new List<Vector3>();

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Au clic gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            //Raycast pour trouver la position du clic
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Cr�ation d'un objet hit pour r�cup�rer les infos
            RaycastHit hit;

            //Si le hit rencontre un collider, celui du NavMesh ici
            if (Physics.Raycast(ray, out hit))  //out indique que hit va etre initialis� dans la fonction et peut donc varier 
            {
                //On d�finit la destination comme �tant la position du clic
                destination = hit.point;

                //Ici, on v�rifie si le GameObject a atteint sa destination  
                if (agent.remainingDistance < 0.1f)
                {
                    //Si oui, on l'envoie � cette nouvelle destination
                    agent.SetDestination(destination);
                }
                else
                {
                    //Sinon, on stocke la nouvelle destination dans la liste
                    destinations.Add(destination);
                }
            }
        }

        //Si le GameObject atteint sa destination pr�c�dente et qu'il en reste d'autres
        if (agent.remainingDistance < 0.1f && destinations.Count > 0)
        {
            //On d�finit la nouvelle d�finition en prenant la premi�re de la liste
            destination = destinations[0];
            
            //Ensuite on la supprime de la liste, pour faire remonter le reste de la liste
            destinations.RemoveAt(0);

            //On envoie le GameObject � la destination s�lectionn�e
            agent.SetDestination(destination);
        }
    }

}
