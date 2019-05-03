using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    [SerializeField] private Button button;

	void Start () {
        button = button.GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
	}

    void LoadLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
