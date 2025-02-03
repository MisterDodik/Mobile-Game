using UnityEngine;

public class pushLogics : MonoBehaviour
{
    GameObject player;
    Rigidbody playerRB;

    public float force = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 6)
        {
            Vector3 direction = player.transform.position - transform.position ;
            playerRB.AddForce(direction.normalized * (1 / distance) * force);
        }
    }
}
