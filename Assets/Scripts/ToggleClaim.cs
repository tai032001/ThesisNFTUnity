using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToggleClaim : MonoBehaviour
{
    [SerializeField] Image claim;
    public Button toggleClaim;
    public void toggle()
    {
        claim.gameObject.SetActive(true);
        toggleClaim.gameObject.SetActive(false);
    }
    public void exit()
    {
        claim.gameObject.SetActive(false);
        toggleClaim.gameObject.SetActive(true);

    }
}
