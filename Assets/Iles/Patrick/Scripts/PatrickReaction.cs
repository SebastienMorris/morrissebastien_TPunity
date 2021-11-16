using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrickReaction : MonoBehaviour
{
    public Transform cube;
    public Transform controlleur;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Dance", true);
        animator.SetFloat("Speed", 0);
        if (Vector3.Distance(transform.position, controlleur.transform.position) < 5)
        {
            int random = Random.Range(0, 2);
            animator.SetBool("Dance", false);
            animator.SetBool("Suspicious", false);
            animator.SetBool("Dead", false);
            animator.SetFloat("Speed", 0.75f);
            if (random == 0)
            {
                animator.SetInteger("Attack Type", Random.Range(1, 4));
                animator.SetTrigger("Attack");
            }
            else
            {
                animator.SetTrigger("Throw");
            }
        }
        else if (Vector3.Distance(transform.position, controlleur.transform.position) < 50)
        {
            animator.SetBool("Dance", false);
            animator.SetBool("Suspicious", false);
            animator.SetBool("Dead", false);
            animator.SetBool("Move", true);
            animator.SetFloat("Speed", 0.75f);
            if (Vector3.Distance(transform.position, controlleur.transform.position) < 25)
            {
                animator.SetFloat("Speed", 1.5f);
            }
        }
        else if (Vector3.Distance(transform.position, controlleur.transform.position) < 75)
        {
            animator.SetBool("Dance", false);
            animator.SetBool("Suspicious", true);
            animator.SetBool("Dead", false);
            animator.SetBool("Move", false);
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetBool("Dance", true);
            animator.SetFloat("Speed", 0);
        }
    }
}