using Unity.VisualScripting;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour
{
    public RuntimeAnimatorController ac1;
    public RuntimeAnimatorController ac2;
    public RuntimeAnimatorController ac3;

    public GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewEnemy(int number, Vector3 location)
    {
        GameObject inst = Instantiate(enemyPrefab, location, Quaternion.identity);

        switch (number)
        {
            case 1:
                inst.GetComponentInChildren<Animator>().runtimeAnimatorController = ac1 as RuntimeAnimatorController;
                inst.GetComponent<Combat>().comboName = "Bat";
                Transform child = inst.transform.GetChild(0); 
                child.position = new Vector3(child.position.x, 0.75f, child.position.z);
                break;
            case 2:
                inst.GetComponentInChildren<Animator>().runtimeAnimatorController = ac2 as RuntimeAnimatorController;
                inst.GetComponent<Combat>().comboName = "Tom";
                child = inst.transform.GetChild(0);
                child.position = new Vector3(child.position.x, 2.25f, child.position.z);
                break;
            case 3:
                inst.GetComponentInChildren<Animator>().runtimeAnimatorController = ac3 as RuntimeAnimatorController;
                inst.GetComponent<Combat>().comboName = "Tourabe";
                child = inst.transform.GetChild(0);
                child.position = new Vector3(child.position.x, 0.75f, child.position.z);
                break;
        }
        inst.GetComponent<Combat>().AssignAttackCombo();
    }
}
