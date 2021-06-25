using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlowManager : MonoBehaviour
{
    public void startGame()
    {
        InputField playerNameInputField = GameObject.Find("PlayerNameField").GetComponent<InputField>(); ;
        PersistenciManager.Instance.PlayerName = playerNameInputField.text;

        SceneManager.LoadScene(1);
    }
}
