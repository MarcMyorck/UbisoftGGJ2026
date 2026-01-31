using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyInstantiator : MonoBehaviour
{
    public AnimatorController ac1;
    public AnimatorController ac2;
    public AnimatorController ac3;

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
                inst.GetComponentInChildren<Animator>().runtimeAnimatorController = ac1;
                inst.GetComponent<Combat>().comboName = "Bat";
                break;
            case 2:
                inst.GetComponentInChildren<Animator>().runtimeAnimatorController = ac2;
                inst.GetComponent<Combat>().comboName = "Tom";
                break;
            case 3:
                inst.GetComponentInChildren<Animator>().runtimeAnimatorController = ac3;
                inst.GetComponent<Combat>().comboName = "Tourabe";
                break;
        }
        inst.GetComponent<Combat>().AssignAttackCombo();
    }
}
