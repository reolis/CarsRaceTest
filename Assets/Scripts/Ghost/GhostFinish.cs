using UnityEngine;

public class GhostFinish : MonoBehaviour
{
    public GameObject ghost;
    public GameObject finish;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            Destroy(ghost);
        }
    }
}
