using UnityEngine;

public class MovingWallSpawner : MonoBehaviour
{
    //-16 17
    private float[] options = { -16, 17 };

    public GameObject movingSegment;

    private float timer;
    private float cooldownTime = 10;

    Transform player;

    public float offset = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = cooldownTime;

        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
            GameObject spawned=(GameObject)Instantiate(movingSegment);
            Vector3 startPos=spawned.transform.position;
            startPos.x = options[Random.Range(0, options.Length)];

            startPos.y = player.position.y + offset;

            spawned.transform.position=startPos;

            timer = cooldownTime;
        }
    }
}
