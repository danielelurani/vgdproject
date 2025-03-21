using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTDamage : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    [SerializeField] private float collisionRadius = 0.3f;

    private GameObject player;
    private CharacterStats playerStats;
    private Animator animator;
    private bool collisionProcessed = false;

    void Start(){

        // prendo l'oggetto player e il suo componente CharacterStats per poi usarlo nella funzione OnTriggerEnter
        player = GameObject.Find("Player");
        playerStats = player.GetComponent<CharacterStats>();

        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (!collisionProcessed && animator.GetBool("Attack") && !animator.GetBool("isDead") && CheckCollision(transform.position, player.transform.position, collisionRadius))
        {
            playerStats.TakeDamage(damage);
            collisionProcessed = true;
            StartCoroutine(WaitForNextAttack());
        }
    }

    bool CheckCollision(Vector3 thisObjPosition, Vector3 otherObjPosition, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(thisObjPosition, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == player)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator WaitForNextAttack(){

        yield return new WaitForSeconds(2f);
        collisionProcessed = false;
    }
}