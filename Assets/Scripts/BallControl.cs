using DG.Tweening;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] private Transform pota;
    [SerializeField] private Transform basketball;

    public Sequence sequence;
    private Basketball basket;

    public float speed;
    public bool isMove;
    public Vector3 firstPos;
    private Vector3 lastPos, movePos;
    public float time;

    private void Awake()
    {
        basket = GameObject.FindObjectOfType<Basketball>();
    }

    private void Start()
    {
        sequence = DOTween.Sequence();
        BallAnim();
    }

    private void FixedUpdate()
    {
        if (Input.touchCount == 1 && isMove)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                time += Time.deltaTime;
                lastPos = touch.position;
                movePos = lastPos - firstPos;
                transform.position += new Vector3(movePos.x, 0, movePos.y) * speed;
            }

            else if (touch.phase == TouchPhase.Ended && movePos.y > 0 && time < 1f)
            {
                if (!basket.isSafe)
                {
                    sequence.Kill();
                    sequence = DOTween.Sequence();
                    sequence
                        .Insert(0f, basketball.DOLocalMove(new Vector3(basketball.localPosition.x, basketball.localPosition.y + 1f, basketball.localPosition.z + 2.5f), 0.35f).SetEase(Ease.OutQuad))
                        .Insert(0.35f, basketball.DOLocalMove(new Vector3(basketball.localPosition.x, 0, basketball.localPosition.z + 5f), 0.35f).SetEase(Ease.InQuad))
                        .OnComplete(BallAnim);
                }
                else
                {
                    Vector3 deltaPos = new Vector3(pota.position.x - basketball.position.x, pota.position.y - basketball.position.y, pota.position.z - basketball.position.z);
                    sequence.Kill();
                    sequence = DOTween.Sequence();
                    sequence
                        .Insert(0, basketball.DOJump(new Vector3(pota.position.x, pota.position.y - 0.2f, pota.position.z), 1.5f, 1, 1));
                }
            }
        }
        else
        {
            time = 0;
            firstPos = Vector3.zero;
            lastPos = Vector3.zero;
            movePos = Vector3.zero;
        }
    }

    void BallAnim()
    {
        sequence.Kill();
        sequence = DOTween.Sequence();

        sequence
            .Insert(0, basketball.DOLocalMoveY(0.4f, 0.3f).SetEase(Ease.OutQuad))
            .Insert(0.3f, basketball.DOLocalMoveY(0f, 0.3f).SetEase(Ease.InQuad))
            .SetLoops(-1)
            .SetId("ballanim");
    }
}
