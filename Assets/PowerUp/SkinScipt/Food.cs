using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField]
    private float Health = 0;

    public float GetHealth()
    {
        return Health;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "Player")
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
