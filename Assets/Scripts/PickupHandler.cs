using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    public List<GameObject> inside = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other) { 
        if(other.tag == "Pickup")
        {
            inside.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Pickup")
        {
            inside.Remove(other.gameObject);
        }
    }

    public GameObject GetClosest(GameObject reference) { 
        GameObject closest = null; 
        float minDist = Mathf.Infinity; 
        foreach (GameObject g in inside) { 
            float dist = Vector3.Distance(reference.transform.position, g.transform.position); 
            if (dist < minDist) { 
                minDist = dist; 
                closest = g; 
            } 
        } 
        return closest; 
    }

    public void PickupCombo(GameObject pickup)
    {
        gameObject.GetComponent<Combat>().comboName = pickup.GetComponent<Pickup>().comboName;
        gameObject.GetComponent<Combat>().AssignAttackCombo();
        inside.Remove(pickup);
        Destroy(pickup);
    }
}
