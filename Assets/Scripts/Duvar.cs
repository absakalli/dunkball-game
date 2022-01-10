using UnityEngine;
using DG.Tweening;

public class Duvar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DOTween.Kill("ballanim");
        }
    }
}
