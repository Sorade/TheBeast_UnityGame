using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisableZone : MonoBehaviour, IPointerEnterHandler {

	public void OnPointerEnter(PointerEventData data){ 
		CustomEventManager.TriggerEvent ("Movement");
	}
}
