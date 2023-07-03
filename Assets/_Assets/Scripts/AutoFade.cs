using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    [SerializeField]
    private float _visibleDuration;
    [SerializeField]
    private float _fadingDuration;
    [SerializeField]
    private CanvasGroup _group;
    private float _startTime;


    public void Show()
    {
        gameObject.SetActive(true);
        _startTime = Time.time;
        SetAlpha(1f);
    }

    private void Update()
    {
        float elapsedTime = Time.time - _startTime;
        if (elapsedTime < _visibleDuration) return;
        elapsedTime -= _visibleDuration;
        if (elapsedTime < _fadingDuration)
        {
            SetAlpha(1f - elapsedTime / _fadingDuration);
        }
        else
            Hide();
    }

    private void SetAlpha(float alpha) => _group.alpha = alpha;

    public void Hide() => gameObject.SetActive(false);


    private void OnValidate() => _group = GetComponent<CanvasGroup>();

}