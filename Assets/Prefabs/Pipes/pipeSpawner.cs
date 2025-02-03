using System.Threading;
using UnityEngine;

public class pipeSpawner : MonoBehaviour
{
    public Material[] materials;

    float timer;

    public Transform spawnPos;
    public float negXOffset;
    public float posXOffset;
    public float comboYOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer=Random.Range(2, 10);
            spawnPipes();
        }

    }

    void spawnPipes()
    {
        int combo = Random.Range(1, 5);
        float randomXOffset = Random.Range(negXOffset, posXOffset);

        float xRotation = Random.Range(-9, -3);
        float yRotation = Random.Range(0, 130);
        float zRotation = -22f;
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, zRotation);

        int randomPipe = Random.Range(0, materials.Length);
        if (combo < 3) // Spawn one pipe
        {
            GameObject pipe = PipeObjectPool.instance.GetObject();
            pipe.transform.position = new Vector3(randomXOffset, spawnPos.position.y, spawnPos.position.z);
            pipe.transform.rotation = rotation;

            pipe.GetComponent<Renderer>().material = materials[randomPipe];
            pipe.tag = "pipe" + (randomPipe+1).ToString();
            pipe.transform.GetComponentInChildren<PipeLogics>().selfIndex = randomPipe;
        }
        else // Spawn multiple pipes
        {
            Vector3 basePosition = new Vector3(randomXOffset, spawnPos.position.y, spawnPos.position.z);
            for (int i = 0; i < combo; i++)
            {
                GameObject pipe = PipeObjectPool.instance.GetObject();
                pipe.transform.position = basePosition + new Vector3(0, -i * comboYOffset, 0);
                pipe.transform.rotation = rotation;

                pipe.GetComponent<Renderer>().material = materials[randomPipe];
                pipe.tag = "pipe" + (randomPipe + 1).ToString();
                pipe.transform.GetComponentInChildren<PipeLogics>().selfIndex = randomPipe;
            }
        }
    }

}
