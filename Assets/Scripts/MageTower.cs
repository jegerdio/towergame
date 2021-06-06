using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTower : MonoBehaviour
{
    public FadeEffect effectscript;

    float damage = 60.0f;
    List<EnemyWizrd> enemies = new List<EnemyWizrd>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("TowerShot", 0.7f, 1.2f );   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TowerShot()
    {
        effectscript.StartFade();
        if(enemies.Count > 0){
            enemies[0].doDamage(damage);
        }
    }

    void OnEnemyDied(EnemyWizrd enemy){
        enemies.Remove(enemy);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject enemyObject = collider.gameObject;
        EnemyWizrd enemyScript = enemyObject.GetComponent<EnemyWizrd>();
        enemyScript.EnemyDied += OnEnemyDied;
        enemies.Add(enemyScript);
        print("I SEE YOU!");
    }

     void OnTriggerExit2D(Collider2D collider)
     {
        GameObject enemyObject = collider.gameObject;
        EnemyWizrd enemyScript = enemyObject.GetComponent<EnemyWizrd>();
        enemies.Remove(enemyScript);
        print("enemy exit");
     }
}
