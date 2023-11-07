using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Threading.Tasks;
using System;
using System.Linq;
using Thirdweb.Examples;
public class CheckCharacterScript : MonoBehaviour
{
    [SerializeField] Text Character;
    public Button CharacterClaim;
    public Button CheckCharacter;
    public Button ButtonPlay;
    public Image characterImage;
    // public Prefab_NFT prefabNft;

    public static string CharacterContract = "0xBE02BA066639F857C033B53Ea7EA7d8D4dEbd957";

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
                Character.gameObject.SetActive(true);
                Character.text = "Current character: Virtual Guy";
                ButtonPlay.gameObject.SetActive(true);
                CharacterClaim.gameObject.SetActive(false);
                CheckCharacter.gameObject.SetActive(false);
                characterImage.gameObject.SetActive(true);
                // NFT nft = await contract.ERC1155.Get("0");
                // Prefab_NFT nftLoad = prefabNft.GetComponent<Prefab_NFT>();
                // nftLoad.LoadNFT(nft);
                // Prefab_NFT nftPrefabScript = prefabNft.GetComponent<Prefab_NFT>();
                // nftPrefabScript.LoadNFT(nft);
                // nftPrefabScript.gameObject.SetActive(true);
            }
            else
            {
                Character.gameObject.SetActive(true);
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