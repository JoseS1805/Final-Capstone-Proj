using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy"))
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }
                if (other.gameObject.CompareTag("Player"))
                {
                    hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                    other.GetComponent<PlayerController>().Knock(knockTime);
                }
            }
        }
        /*
        if (other.gameObject.CompareTag("breakable") && this.gameObjsect.CompareTag("Player"))
        {
            other.GetComponent<pot>().Smash();
        }
        */
    }
}
