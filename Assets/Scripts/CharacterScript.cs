// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
// using System.Threading.Tasks;
using System;
using Thirdweb.Examples;
// using System.Linq;
public class CharacterScript : MonoBehaviour
{
    [SerializeField] Text Character;
    public Button CharacterClaim;
    public Button ButtonPlay;
    // public Prefab_NFT prefabNft;

    public Image characterImage;

    public static string CharacterContract = "0x27A3c8743D92717cE2A226B1f7a6Ed5f40E85799";
    public static string addressWallet;
    public async void getTokenBalance()
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
                Character.gameObject.SetActive(true);
                Character.text = "Current character: Virtual Guy";
                ButtonPlay.gameObject.SetActive(true);
                CharacterClaim.gameObject.SetActive(false);
                characterImage.gameObject.SetActive(true);
                // NFT nft = await contract.ERC1155.Get("0");
                // Prefab_NFT nftLoad = prefabNft.GetComponent<Prefab_NFT>();
                // nftLoad.LoadNFT(nft);
            }
            else
            {
                Character.gameObject.SetActive(true);
                Character.text = "Please claim character to play";
                CharacterClaim.gameObject.SetActive(true);
                ButtonPlay.gameObject.SetActive(false);
            }
        }
        catch (System.Exception)
        {
            Debug.Log("Error while get balance");
            throw;

        }
    }
    public void onDisconnect()
    {
        Character.text = "Please connect wallet to check character";
        CharacterClaim.gameObject.SetActive(false);
        ButtonPlay.gameObject.SetActive(false);
        characterImage.gameObject.SetActive(false);
    }
}