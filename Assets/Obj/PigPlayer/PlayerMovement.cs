using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;
    public GameObject Bomb;
    private FixedJoystick jostic;

    public bool activeBomb = false;

    private void Start()
    {
        jostic = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        controller = GetComponent<CharacterController2D>();
        activeBomb = false;
    }

    private void Update()
    {
        float x = jostic.Horizontal;
        float y = jostic.Vertical;

        if (Input.GetKey(KeyCode.W)) y = 1;
        if (Input.GetKey(KeyCode.S)) y = -1;
        if (Input.GetKey(KeyCode.D)) x = 1;
        if (Input.GetKey(KeyCode.A)) x = -1;



        if (Input.GetKeyDown(KeyCode.E)) SetBomb();

        controller.Move(x, y);
    }

    IEnumerator KDBomb()
    {
        yield return new WaitForSeconds(2f);
        activeBomb = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dog")
        {
            GameObject.Find("Main Camera").GetComponent<ConstructScene>().DogWin();
            Destroy(gameObject);
        }
    }

    public void SetBomb()
    {
        if (activeBomb == false)
        {
            activeBomb = true;
            Instantiate(Bomb, transform.position, Quaternion.identity);
            StartCoroutine(KDBomb());
        }
    }
}
