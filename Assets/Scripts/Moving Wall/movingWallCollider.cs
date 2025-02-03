using UnityEngine;

public class movingWallCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("kraj");
        }
    }
}
