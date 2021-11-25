using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Active());
    }

    IEnumerator Active()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Active");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
