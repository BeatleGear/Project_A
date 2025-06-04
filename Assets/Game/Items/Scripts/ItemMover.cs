using DG.Tweening;
using UnityEngine;

public class ItemMover : MonoBehaviour
{
    public Sequence Animation;
    public float DeltaY;
    // Start is called before the first frame update
    void Start()
    {
        Animation = DOTween.Sequence();
        if (transform != null)
        {
            Animation
                .Append(transform.DOMoveY(DeltaY, 0.5f).From(false).SetEase(Ease.Linear).SetLoops(int.MaxValue, LoopType.Yoyo))
                .Join(transform.DORotate(new Vector3(0, 360, 0), 2.0f, RotateMode.FastBeyond360).From().SetEase(Ease.Linear).SetLoops(int.MaxValue));
        }


            
        //SinusMover();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SinusMover()
    {
        transform.DOMoveY(2, 0.5f).From(false).SetLoops(-1, LoopType.Yoyo);
    }
    private void OnDestroy()
    {
        Animation.Kill();
    }
}
