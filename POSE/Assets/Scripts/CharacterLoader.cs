using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    public GameObject character3;

    void Start()
    {
        // Leer los estados guardados de PlayerPrefs
        bool character1Selected = PlayerPrefs.GetInt("Character1Selected", 0) == 1;
        bool character2Selected = PlayerPrefs.GetInt("Character2Selected", 0) == 1;
        bool character3Selected = PlayerPrefs.GetInt("Character3Selected", 0) == 1;

        // Activar/desactivar los personajes según los estados guardados
        character1.SetActive(character1Selected);
        character2.SetActive(character2Selected);
        character3.SetActive(character3Selected);
    }
}
