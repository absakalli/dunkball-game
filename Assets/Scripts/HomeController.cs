using DG.Tweening;
using UnityEngine;

public class HomeController : MonoBehaviour
{
    [SerializeField] private GameObject settingBut;
    [SerializeField] private GameObject playInfo;
    [SerializeField] private GameObject skinBut;
    [SerializeField] private GameObject background;

    BallControl ballControl;

    private void Awake()
    {
        playInfo.SetActive(true);
        skinBut.SetActive(true);
    }

    void Start()
    {
        ballControl = GameObject.FindObjectOfType<BallControl>();
        ballControl.isMove = false;
        settingBut.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        playInfo.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
        skinBut.GetComponent<CanvasGroup>().DOFade(1, 0.3f);
    }

    public void Click()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (background.GetComponent<CanvasGroup>().alpha == 1)
            {
                ballControl.isMove = true;
                ballControl.firstPos = touch.position;
                playInfo.SetActive(false);
                skinBut.SetActive(false);
                background.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
            }
            else
            {
                ballControl.firstPos = touch.position;
            }
        }
    }
}
