using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatGameEventListener : MonoBehaviour
{
	[SerializeField] public FloatGameEvent Event; // O evento responsável pela ação.
	[SerializeField] public UnityEvent<float> Response; // Resposta do Evento, o que aconteceu?

	private void OnEnable()
	{ Event.RegisterListener(this); }

	private void OnDisable()
	{ Event.UnregisterListener(this); }

	public void OnEventRaised(float value)
	{ Response.Invoke(value); }
}
