using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIDogControll : MonoBehaviour
{

    private CharacterController2D controller;

    float x = 0;
    float y = 0;

    bool active = false;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if(active == false)
        {
            active = true;
            int r = Random.Range(1, 100);

            if (r > 75)                
                StartCoroutine(Move(1,0));
            else if(r > 50)
                StartCoroutine(Move(-1, 0));
            else if (r > 25)
                StartCoroutine(Move(0, 1));
            else if (r > 0)
                StartCoroutine(Move(0, -1));
        }

        controller.Move(x, y);
    }

    IEnumerator Move(float Inputx, float Inputy)
    {
        x = Inputx;
        y = Inputy;

        yield return new WaitForSeconds(1);

        x = 0;
        y = 0;

        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bomb")
        {
            GameObject.Find("Main Camera").GetComponent<ConstructScene>().PigWin();
            Destroy(gameObject);    
        }
    }

}
