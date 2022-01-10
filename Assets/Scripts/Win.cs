using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] public GameObject konfeti, konfeti2;
    private Transform parent, asagi;

    BallControl ballControl;

    private bool isTrigger;

    private void Awake()
    {
        ballControl = GameObject.FindObjectOfType<BallControl>();
    }

    private void Start()
    {
        parent = gameObject.transform.parent;
        asagi = parent.transform.GetChild(1);
        asagi.GetComponent<Collider>().isTrigger = false;
        isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isTrigger)
        {            
            asagi.GetComponent<Collider>().isTrigger = true;
            Instantiate(konfeti, transform.position + new Vector3(.6f, .6f, 0), Quaternion.Euler(-60, 90, -90));
            Instantiate(konfeti, transform.position + new Vector3(-.6f, .6f, 0), Quaternion.Euler(-120, 90, -90));
            Instantiate(konfeti2, transform.position, Quaternion.identity);
            isTrigger = false;
            ballControl.isMove = false;
        }
    }
}
