using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrzyspieszenieLewo : MonoBehaviour
{
    [SerializeField] int speed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kulka"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(speed * Vector3.right, ForceMode.Impulse);
        }
    }
}
