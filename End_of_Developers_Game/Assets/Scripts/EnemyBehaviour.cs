using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 30;
    public HealthBarBehaviour Healthbar;
    public Text minNum;
    public Text maxNum;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);
        int num1 = Random.Range(1, 81);
        int num2 = Random.Range(1, 21);
        num2 += num1;

        minNum.text = num1.ToString();
        maxNum.text = num2.ToString();

    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Bunny Destroyed");
        }
    }
}
