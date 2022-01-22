using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreator : MonoBehaviour {

    private int screenWidth = Screen.width;
    private int screenHeight = Screen.height;

    public int count = 0;
    float time = 5;
    int amount = 0;

    public GameObject enemy;


    void Start(){

        count = 8;
        StartCoroutine(makeEnemies());
        amount = screenWidth / 35;
    }


    IEnumerator makeEnemies() {

        for(int i = 1; i < amount; i = i + 1){

            int indent = 40;

            Vector3 position = new Vector3( i * indent - indent / 4 - indent /5, screenHeight + 30 , 8);
            position = Camera.main.ScreenToWorldPoint(position);
            Instantiate(enemy, position, transform.rotation);
            enemyController eC = enemy.GetComponent<enemyController>();
            eC.num = count;
            eC.addHealth();
            
        }

        
        count += 1;

        yield return new WaitForSeconds(time);
        if (time > 0.5)
        {
            time -= 0.2f;
        }
        yield return null;

        StartCoroutine(makeEnemies());
    }
}
