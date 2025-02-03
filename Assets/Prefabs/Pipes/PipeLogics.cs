using UnityEngine;

public class PipeLogics : MonoBehaviour
{
    GameObject player;
    playerController playerController;

    public GameObject particles;

    public int selfIndex;
    public static PipeLogics instance;
    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController=player.GetComponent<playerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            if(playerController.instance.currentElement==selfIndex)
                playerController.changeSpeed(-20);
            else
                playerController.changeSpeed(+80);
            hitActions();
        }
        else if (other.gameObject.tag == "ender")
        {
            PipeObjectPool.instance.ReturnObject(transform.parent.gameObject);
        }
    }
    private void hitActions()
    {
        //particles.GetComponent<ParticleSystem>().Play();
        PipeObjectPool.instance.ReturnObject(transform.parent.gameObject);

    }
}
