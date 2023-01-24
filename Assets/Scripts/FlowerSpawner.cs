using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    //Objet � instancier
    [SerializeField] private GameObject _newFlower;

    [SerializeField] private GameObject _ground;

    //Liste pour stocker les objets
    public List<GameObject> _flowers = new();

    //Le premier objet stock� dans la liste
    private GameObject _firstFlowerOfTheList;

    //Nombre maximum d'objets 
    public int _nbrMaxFlower;

    //Nomnre d'objets cr��s (� comparer au max d'objets)
    public int _nbrOfFlower;

    // Start is called before the first frame update
    void Start()
    {
        _nbrOfFlower = 0;
        _nbrMaxFlower = 10;
        StartCoroutine("SeedsOfFlowers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SeedsOfFlowers()
    {
        yield return new WaitForSeconds(2.0f);

        if (_nbrOfFlower < _nbrMaxFlower)
        { 
 
            float randomRange = Random.Range(-4.5f, 4.5f);

            Vector3 randomPosition = new Vector3(randomRange, 0f, randomRange);
 
            Instantiate(_newFlower, randomPosition, Quaternion.identity);    //Instanciation

            _flowers.Add(_newFlower);   //On l'ajoute � la liste

            _nbrOfFlower++;     //Incr�ment du compteur / condition du if
        }
        //L�, on recycle les objets de la liste quand on a atteint le quotat d'objets
        else if (_nbrOfFlower == _nbrMaxFlower)
        {
            _firstFlowerOfTheList = _flowers[0]; //On cible le premier objet de la liste, donc le plus ancien

            _firstFlowerOfTheList.transform.position = _ground.transform.position;    //Instanciation de l'objet � la position 

            _flowers.RemoveAt(0); //on retire l'objet � l'index 0, premier de la liste

            _flowers.Add(_firstFlowerOfTheList);   //On l'ajoute � la fin de la liste
        }
    }

    
}
