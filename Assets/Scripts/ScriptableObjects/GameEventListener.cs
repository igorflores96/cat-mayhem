using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	public GameEvent Event; // O evento responsável pela ação.
	public UnityEvent Response; // Resposta do Evento, o que aconteceu?

	private void OnEnable()
	{ Event.RegisterListener(this); }

	private void OnDesable()
	{ Event.UnregisterListener(this); }

	public void OnEventRaised()
	{ Response.Invoke(); }
}
