using UnityEngine;

public class SpawnGhost : MonoBehaviour
{
    public GameObject ghost;
    public Transform spawn;
    Rigidbody rb;
    int currentPoint = 0;
    float speed = 20f;
    Vector3 offset;

    void Start()
    {
        ghost.SetActive(false);
        StartCoroutine(WaitForCountAndSpawn());
    }

    System.Collections.IEnumerator WaitForCountAndSpawn()
    {
        yield return new WaitUntil(() => CollideFinish.count == 1);

        ghost.SetActive(true);

        if (CarProcess.positions.Count > 0)
        {
            rb = ghost.GetComponent<Rigidbody>();

            offset = spawn.position - CarProcess.startPosition;
        }
    }

    void FixedUpdate()
    {
        if (rb != null && CarProcess.positions.Count > 0)
        {
            Vector3 targetPos = CarProcess.positions[currentPoint] + offset;
            Quaternion targetRot = CarProcess.quaternions[currentPoint];
            rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, speed * Time.fixedDeltaTime));
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRot, 5f * Time.deltaTime);

            if (Vector3.Distance(rb.position, targetPos) < 0.01f)
            {
                currentPoint = (currentPoint + 1) % CarProcess.positions.Count;
            }
        }
    }
}