using System;
using UnityEngine;

public class CollideFinish : MonoBehaviour
{
    public GameObject finish;
    public GameObject player;
    public static int count = 0;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("Finish is reached!");
            Debug.Log($"Positions list: {string.Join(';', CarProcess.positions)}");
            count++; // —читаем количество гонок

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                rb.position = CarProcess.startPosition;
                rb.rotation = CarProcess.startRotation;
            }
            else
            {
                collision.transform.SetPositionAndRotation(
                    CarProcess.startPosition,
                    CarProcess.startRotation
                );
            }
        }
    }
}
