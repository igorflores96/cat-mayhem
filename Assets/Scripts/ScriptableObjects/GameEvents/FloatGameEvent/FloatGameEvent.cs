using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatGameEvent", menuName = "GameEvents/FloatGameEvent", order = 1)] /*Aqui nos temos 3 atributos, fileName (nome do arquivo sendo criado, no caso, GameEvent), 
menuName (onde vai ser arquivado, é sempre dentro da pasta de assets/nome_dado/nome_criado e order (ordem que vai aparecer no editor da unity, lá no menu de criação).*/

public class FloatGameEvent : ScriptableObject
{
	private List<FloatGameEventListener> listeners = new List<FloatGameEventListener>(); // Cria a lista de Inscritos.

	public void Raise(float value)
	{
		for (int i = listeners.Count - 1; i >= 0; i--) //Da um Raise nesses Game Events, cria os eventos.
			listeners[i].OnEventRaised(value);
	}

	public void RegisterListener(FloatGameEventListener listener) // Registra como um inscrito.
	{ listeners.Add(listener); }

	public void UnregisterListener(FloatGameEventListener listener) // Des Registra como um inscrito.
	{ listeners.Remove(listener); }
}
