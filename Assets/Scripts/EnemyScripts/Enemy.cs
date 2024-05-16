using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;

    public void Knock(Rigidbody2D myRB, float knockTime)
    {
        StartCoroutine(KnockCo(myRB, knockTime));
    }
    private IEnumerator KnockCo(Rigidbody2D myRB, float knockTime)
    {
        if (myRB != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRB.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRB.velocity = Vector2.zero;
        }
    }
}
