using UnityEngine;

public class Basketball : MonoBehaviour
{
    [SerializeField] private AudioClip boing;
    [SerializeField] private GameObject boncball;
    [SerializeField] private GameObject playBack;

    AudioSource audioSource;

    public bool isSafe;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isSafe = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ballanim;
        if (collision.collider.tag == "Ground")
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;
            ballanim = Instantiate(boncball, pos, Quaternion.Euler(90, 0, 0));
            Destroy(ballanim, 0.5f);
            if (PlayerPrefs.GetInt("Sound") == 1 && playBack.GetComponent<CanvasGroup>().alpha == 0)
            {
                audioSource.PlayOneShot(boing, 0.1f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Safe")
        {
            isSafe = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Safe")
        {
            isSafe = false;
        }
    }
}
