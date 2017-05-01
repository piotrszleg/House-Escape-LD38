using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunctions : MonoBehaviour {

	public void ReloadScene () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
    public void SelectInstead(GameObject toSelect)
    {
        toSelect.SetActive(true);
        gameObject.SetActive(false);
    }
}
