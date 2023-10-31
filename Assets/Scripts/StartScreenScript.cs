using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenScript : MonoBehaviour
{
    public void toggleButtonPlayGame(Button PlayGameButton)
    {
        PlayGameButton.gameObject.SetActive(true);
    }
}
