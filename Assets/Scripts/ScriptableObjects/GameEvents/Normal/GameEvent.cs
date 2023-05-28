using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvents/GameEvent", order = 1)] /*Aqui nos temos 3 atributos, fileName (nome do arquivo sendo criado, no caso, GameEvent), 
menuName (onde vai ser arquivado, é sempre dentro da pasta de assets/nome_dado/nome_criado e order (ordem que vai aparecer no editor da unity, lá no menu de criação).*/

public class GameEvent : ScriptableObject
{
	private List<GameEventListener> listeners = new List<GameEventListener>(); // Cria a lista de Inscritos.

	public void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--) //Da um Raise nesses Game Events, cria os eventos.
			listeners[i].OnEventRaised();
	}

	public void RegisterListener(GameEventListener listener) // Registra como um inscrito.
	{ listeners.Add(listener); }

	public void UnregisterListener(GameEventListener listener) // Des Registra como um inscrito.
	{ listeners.Remove(listener); }
}
