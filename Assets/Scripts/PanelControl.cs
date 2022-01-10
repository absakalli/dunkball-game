using DG.Tweening;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    [SerializeField] public GameObject[] arkaObjects;
    [SerializeField] public GameObject settingsPanel, skinsPanel;
    [SerializeField] public GameObject playBack;

    BallControl ballControl;

    private void Start()
    {
        ballControl = GameObject.FindObjectOfType<BallControl>();
    }

    void Arkay�Kapat()
    {
        foreach (var obje in arkaObjects)
        {
            obje.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        }
    }

    void Arkay�Ac()
    {
        foreach (var obje in arkaObjects)
        {
            obje.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        }
    }

    public void SettingsPanel()
    {
        ballControl.isMove = false;
        Arkay�Kapat();
        settingsPanel.SetActive(true);
        settingsPanel.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
    }

    public void SkinsPanel()
    {
        ballControl.isMove = false;
        Arkay�Kapat();
        skinsPanel.SetActive(true);
        skinsPanel.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
    }

    public void Back()
    {
        if (playBack.GetComponent<CanvasGroup>().alpha==0)
        {
            ballControl.isMove = true;
        }
        skinsPanel.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        settingsPanel.GetComponent<CanvasGroup>().DOFade(0, 0.3f);
        skinsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        Arkay�Ac();
    }
}
