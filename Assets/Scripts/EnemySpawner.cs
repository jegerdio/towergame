using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject baseEnemy;
    public Text userText;

    private int maxHp = 100;
    private int userHp = 100;

    void Start()
    {
        userText.text = userHp.ToString() + "/" + maxHp.ToString();
        InvokeRepeating("CreateNewEnemy", 0.0f, 2.3f);
    }
    void CreateNewEnemy() {
        GameObject newEnemy = GameObject.Instantiate(baseEnemy);
        EnemyWizrd enemyScript = newEnemy.GetComponent<EnemyWizrd>();

        enemyScript.EnemyFinish += EnemyFinishCallback;
    }
    void Update()
    {
        
    }

    void EnemyFinishCallback(EnemyWizrd wizard) {
        userHp -= wizard.damage;
         userText.text = userHp.ToString() + "/" + maxHp.ToString();
    }
}
