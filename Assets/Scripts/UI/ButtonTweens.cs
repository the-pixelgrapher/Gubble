using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonTweens : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField, Tooltip("Scale of element when pointer is pressed (e.g 0.95)")]
    private Vector2 m_pressedScale = Vector2.one;

    [SerializeField, Tooltip("Duration of tween when pointer is pressed (e.g 0.025)")]
    private float m_tweenInDuration = 0.025f;

    [SerializeField, Tooltip("Duration of tween when pointer is released (e.g 0.1)")]
    private float m_tweenOutDuration = 0.1f;

    [SerializeField, Tooltip("Prevent tween from playing if locked")]
	private bool m_locked = false;

    private Vector2 m_originalScale;
    private Tween m_tween = null;
    private Tween m_tween2 = null;

    private Sequence m_sequenceTemplate = null;
    private Sequence m_playingSequence = null;

    private void Awake() 
    {
        m_originalScale = transform.localScale;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
		if (m_locked)
		{
			return;
		}
        // Kill the current tween before running the new one
        //m_tween?.Kill(true);
        //m_tween = transform.DOScale(m_pressedScale * m_originalScale, m_tweenInDuration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
		if (m_locked)
		{
			return;
		}
        // Kill the current tween before running the new one
        //m_tween?.Kill(true);
        //m_tween = transform.DOScale(m_originalScale, m_tweenOutDuration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        m_tween2?.Kill(true);
        m_tween2 = transform.DOPunchRotation(Vector3.one * 10.0f, 0.5f);

    }

    private void OnDestroy() 
    {
        m_tween?.Kill();
    }
}