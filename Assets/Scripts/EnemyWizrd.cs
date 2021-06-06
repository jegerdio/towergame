using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizrd : MonoBehaviour
{
    public delegate void EnemyListener(EnemyWizrd enemy);
    public event EnemyListener EnemyFinish;
    public event EnemyListener EnemyDied;
    public Animator animator;
    public int damage = 4;
    float healht = 100.0f;
    float speed = 0.8f;
    int index = 0;
    bool isMoving = false;

    Vector3 target;
    List<GameObject> checkpoints = new  List<GameObject>();
    
    void Start()
    {
      checkpoints.Add(GameObject.Find("ch1"));
      checkpoints.Add(GameObject.Find("ch2"));
      checkpoints.Add(GameObject.Find("ch3"));
      checkpoints.Add(GameObject.Find("ch4"));
      checkpoints.Add(GameObject.Find("ch5"));
      checkpoints.Add(GameObject.Find("ch6"));
      checkpoints.Add(GameObject.Find("ch7"));
      checkpoints.Add(GameObject.Find("ch8"));
      
        target = checkpoints[index].transform.position;
        isMoving=true;
    }

   
    void Update()
    {
       if(isMoving == true){
           moveEnemy();
       }
    }
    void moveEnemy()
    {
 float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        float distance = Vector3.Distance(transform.position, target);
        if (distance < 0.1f) {
            index++;
            if (index < checkpoints.Count) {
                target = checkpoints[index].transform.position;
            } else {
                if (EnemyFinish != null) {
                    EnemyFinish(this);
                }
                GameObject.Destroy(gameObject);
            }
        }
    }



    public void doDamage(float inputDamage)
    {
        healht -= inputDamage;
        if(healht<= 0){
            if(EnemyDied != null)
            {
               
                EnemyDied(this);
            }
            isMoving = false;
            animator.Play("die");
        }else{
                isMoving = false;
                animator.Play("damage");
            }
    }
    public void endDieAnimation(){
        GameObject.Destroy(gameObject);
    }
    public void damageAnimationEnd(){
        isMoving = true;
        animator.Play("WizardRun");
    }

}
