using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private void Start()
    {
        if (Random.Range(1, 100) > 90) Destroy(gameObject);
    }
}
