using UnityEngine;

public class followPlayerOnAxis : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y= player.position.y;
        transform.position = pos;
    }
}
