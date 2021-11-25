using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D rigitbody;
    private Animator animator;

    [Range(1,10)]
    public float SpeedMove = 1;

    private void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Move(float x, float y)
    {
        try
        {
            if (System.Math.Abs(x) > System.Math.Abs(y)) animator.SetBool("Up", false);
            else if (System.Math.Abs(x) < System.Math.Abs(y)) animator.SetBool("Up", true);

            animator.SetFloat("x", x); animator.SetFloat("y", y);

            transform.position += new Vector3(x, y, 0) * SpeedMove * Time.deltaTime;

            rigitbody.MovePosition(transform.position);
        }
        catch 
        {

            Debug.Log("Eroor Move - " + gameObject.name);
        }
           
    }
}