using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public Toggle toggleCharacter1;
    public Toggle toggleCharacter2;
    public Toggle toggleCharacter3;

    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

    void Start()
    {
        // Cargar el estado de los toggles desde PlayerPrefs
        toggleCharacter1.isOn = PlayerPrefs.GetInt("Character1Selected", 0) == 1;
        toggleCharacter2.isOn = PlayerPrefs.GetInt("Character2Selected", 0) == 1;
        toggleCharacter3.isOn = PlayerPrefs.GetInt("Character3Selected", 0) == 1;

        // Añadir listeners a los toggles para que llamen a los métodos cuando se cambien
        toggleCharacter1.onValueChanged.AddListener(delegate { ToggleCharacter(toggleCharacter1, character1); });
        toggleCharacter2.onValueChanged.AddListener(delegate { ToggleCharacter(toggleCharacter2, character2); });
        toggleCharacter3.onValueChanged.AddListener(delegate { ToggleCharacter(toggleCharacter3, character3); });

        // Inicializar los personajes según el estado de los toggles
        InitializeCharacters();
    }

    void ToggleCharacter(Toggle toggle, GameObject character)
    {
        character.SetActive(toggle.isOn);

        // Guardar el estado del toggle en PlayerPrefs
        string key = "Character" + character.name.Replace("Character", "") + "Selected";
        PlayerPrefs.SetInt(key, toggle.isOn ? 1 : 0);
        PlayerPrefs.Save();  // Asegurarse de que los datos se guardan
    }

    void InitializeCharacters()
    {
        // Inicializa los personajes según el estado de los toggles
        character1.SetActive(toggleCharacter1.isOn);
        character2.SetActive(toggleCharacter2.isOn);
        character3.SetActive(toggleCharacter3.isOn);
    }

    public void StartGame(int n)
    {
        SaveToggleStates();
        SceneManager.LoadScene(n);
    }

    void SaveToggleStates()
    {
        PlayerPrefs.SetInt("Character1Selected", toggleCharacter1.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Character2Selected", toggleCharacter2.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Character3Selected", toggleCharacter3.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
