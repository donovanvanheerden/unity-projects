using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

	private void OnDrawGizmos() {
		Gizmos.DrawWireSphere(this.GetComponent<Transform>().position, 1);
	}

}
