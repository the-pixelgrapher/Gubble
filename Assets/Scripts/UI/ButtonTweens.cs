using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField, Tooltip("Ring that radiates outward when button is clicked")]
    private CanvasGroup ring;

    [SerializeField, Tooltip("Prevent tween from playing if locked")]
	private bool m_locked = false;

    private Vector2 m_originalScale;
    private Tween m_tween = null;

    private Tween[] m_clickTweens;
    private bool m_clickTweensInitialized;

    private Sequence m_sequenceTemplate = null;
    private Sequence m_playingSequence = null;

    private void Awake() 
    {
        m_originalScale = transform.localScale;
        m_clickTweens = new Tween[3];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
		if (m_locked)
		{
			return;
		}
        // Kill the current tween before running the new one
        m_tween?.Kill(true);
        m_tween = transform.DOScale(m_pressedScale * m_originalScale, m_tweenInDuration);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
		if (m_locked)
		{
			return;
		}
        // Kill the current tween before running the new one
        m_tween?.Kill(true);
        m_tween = transform.DOScale(m_originalScale, m_tweenOutDuration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        for (int i = 0; i < m_clickTweens.Length; i++)
        {
            m_clickTweens[i].Kill(true);
        }

        ring.alpha = 0.5f;
        ring.transform.localScale = Vector3.one;

        m_clickTweens[0] = transform.DOPunchRotation(Vector3.one * 15.0f, 0.3f);
        m_clickTweens[1] = ring.transform.DOScale(Vector3.one * 2.0f, 0.3f);
        m_clickTweens[2] = ring.DOFade(0.0f, 0.3f);

    }

    private void OnDestroy() 
    {
        m_tween?.Kill();
    }
}