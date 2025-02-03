using UnityEngine;

public class SpinnerController : MonoBehaviour
{
    public float rotationSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        rotation.z += rotationSpeed;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
