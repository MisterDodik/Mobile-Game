using UnityEngine;

public class magnetSpawner : MonoBehaviour
{

    public GameObject magnetPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void onClick(Vector2 input)
    {
        GameObject magnet= (GameObject)Instantiate(magnetPrefab);

        Vector3 realPos = Camera.main.ScreenToWorldPoint((new Vector3(input.x, input.y, 21)));

        realPos.z= magnet.transform.position.z;
       
        magnet.transform.position = realPos;
    }

}
