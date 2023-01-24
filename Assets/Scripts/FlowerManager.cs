using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    private Vector3 scaleChange;
    private Vector3 positionChange;
    private bool mustGrow;
    private float timeBeforeVanish;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(0.25f, 0.25f, 0.25f);
        positionChange = new Vector3(0, 0.25f, 0);
        mustGrow = true;
        timeBeforeVanish = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustGrow)
        {
            if(timeBeforeVanish > 0)
            {
                timeBeforeVanish -= Time.deltaTime;
                print(timeBeforeVanish);
            }
            if(timeBeforeVanish <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && mustGrow)
        {
            print("Time to grow bigger !");
            mustGrow = false;
            StartCoroutine(timeToGrow());
        }
    }

    IEnumerator timeToGrow()
    {
        Vector3 scaleChange = new Vector3(0.25f, 0.25f, 0.25f);
        Vector3 positionChange = new Vector3(0, 0.25f, 0);
        yield return new WaitForSeconds(2.0f);
        transform.localScale += scaleChange;
        transform.position += positionChange;
    }
}
