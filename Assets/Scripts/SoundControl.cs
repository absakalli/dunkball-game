using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [SerializeField] public GameObject on, off;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", PlayerPrefs.GetInt("Sound"));

            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                on.SetActive(false);
                off.SetActive(true);
            }
            else
            {
                on.SetActive(true);
                off.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
    }

    public void SesAc()
    {
        PlayerPrefs.SetInt("Sound", 1);
        on.SetActive(true);
        off.SetActive(false);
    }

    public void SesKapat()
    {
        PlayerPrefs.SetInt("Sound", 0);
        on.SetActive(false);
        off.SetActive(true);
    }
}
