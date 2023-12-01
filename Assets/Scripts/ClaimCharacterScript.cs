using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
public class ClaimCharacterHandle : MonoBehaviour
{
    [SerializeField] Image claim;

    public Text ResultClaim;
    public Button claimButton;
    public Button claimButtonAgain;
    public Button checkCharacter;
    public static string CharacterContract = "0x27A3c8743D92717cE2A226B1f7a6Ed5f40E85799";

    public async void ClaimCharacter()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(CharacterContract);
            var data = await contract.ERC1155.Claim("0", 1);
            ResultClaim.gameObject.SetActive(true);
            // ResultClaim.text = "Success";
            claim.gameObject.SetActive(false);
            claimButton.gameObject.SetActive(false);
            claimButtonAgain.gameObject.SetActive(false);
            checkCharacter.gameObject.SetActive(true);
        }
        catch (System.Exception)
        {
            claimButtonAgain.gameObject.SetActive(true);
            ResultClaim.gameObject.SetActive(true);
            ResultClaim.text = "Failed";
            claimButton.gameObject.SetActive(false);
            Debug.Log("Error while get balance");
            throw;

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
