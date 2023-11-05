using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Threading.Tasks;
using System;
using System.Linq;
public class CheckCharacterScript : MonoBehaviour
{
    [SerializeField] Text Character;
    public Button CharacterClaim;
    public Button CheckCharacter;
    public Button ButtonPlay;

    public static string CharacterContract = "0x3694c04aBfD11A4B04668Bfe0AF744ac96Ee3972";
    public static string addressWallet;
    public async void checkCharacter()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(CharacterContract);
            var data = await contract.ERC1155.Balance("0");
            var dataa = Int32.Parse(data);
            Debug.Log(data);
            if (dataa >= 1)
            {
                Character.text = "Current character: Virtual Guy";
                ButtonPlay.gameObject.SetActive(true);
                CharacterClaim.gameObject.SetActive(false);
                CheckCharacter.gameObject.SetActive(false);
            }
            else
            {
                Character.text = "Please claim character to play";
                CharacterClaim.gameObject.SetActive(true);
                ButtonPlay.gameObject.SetActive(false);
                CheckCharacter.gameObject.SetActive(false);
            }
        }
        catch (System.Exception)
        {
            Debug.Log("Error while get balance");
            throw;

        }
    }
}