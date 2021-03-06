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

    void ArkayıKapat()
    {
        foreach (var obje in arkaObjects)
        {
            obje.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
        }
    }

    void ArkayıAc()
    {
        foreach (var obje in arkaObjects)
        {
            obje.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        }
    }

    public void SettingsPanel()
    {
        ballControl.isMove = false;
        ArkayıKapat();
        settingsPanel.SetActive(true);
        settingsPanel.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
    }

    public void SkinsPanel()
    {
        ballControl.isMove = false;
        ArkayıKapat();
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
        ArkayıAc();
    }
}
