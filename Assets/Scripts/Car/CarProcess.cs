using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarProcess : MonoBehaviour
{
    public GameObject Car;
    Rigidbody rb;
    public float maxSpeed = 5f;
    public float acceleration = 10f;

    public static List<Vector3> positions;
    public static List<Quaternion> quaternions;
    public static Vector3 startPosition;
    public static Quaternion startRotation;

    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        positions = new List<Vector3>(); // Для призрака
        quaternions = new List<Quaternion>(); // Для призрака
        startPosition = Car.transform.position; // Позиции для респавна
        startRotation = Car.transform.rotation; // Повороты для респавна
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb != null)
        {
            scoreText.text = $"Race: {CollideFinish.count.ToString()}";

            Vector3 input = Vector3.zero;

            if (Keyboard.current.wKey.IsPressed()) input += Vector3.forward;
            if (Keyboard.current.sKey.IsPressed()) input += Vector3.back;
            if (Keyboard.current.dKey.IsPressed()) input += Vector3.right;
            if (Keyboard.current.aKey.IsPressed()) input += Vector3.left;

            input = input.normalized;

            Vector3 desiredVelocity = input * maxSpeed;
            rb.linearVelocity = Vector3.MoveTowards(rb.linearVelocity, desiredVelocity, acceleration * Time.fixedDeltaTime);

            SaveProgress();
        }
    }

    // Сохранить прогресс
    private void SaveProgress()
    {
        positions.Add(rb.transform.position);
        quaternions.Add(rb.transform.rotation);
    }
}
