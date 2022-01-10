using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
