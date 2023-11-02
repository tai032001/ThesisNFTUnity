using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Threading.Tasks;
public class TokenBalanceScript : MonoBehaviour
{
    [SerializeField] private Text TokenBalance;
    // [SerializeField] private Text CherriesEarned;
    // [SerializeField] private Button ClaimButton;
    void Start()
    {

    }

    public static string ERC_20_Contract = "0x659a1497306b2225a261e6b85789bD641C290EcD";
    public static string addressWallet;
    public async void getTokenBalance()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract("0x117Ed9670840c7722994098568c2EDd9BdFbeFcC");
            var data = await contract.ERC20.BalanceOf(address);
            TokenBalance.text = "Token Cherry: " + data.displayValue;
        }
        catch (System.Exception)
        {
            Debug.Log("Error while get balance");
            throw;

        }
    }
    // public async void claimToken()
    // {
    //     try
    //     {
    //         var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
    //         Contract contract = ThirdwebManager.Instance.SDK.GetContract(ERC_20_Contract);
    //         var result = await contract.ERC20.Claim(ItemCollector.cherries.ToString());
    //         CherriesEarned.text = "Claim Token Successfully";
    //         // CherriesEarned.text = address;
    //         ClaimButton.gameObject.SetActive(false);
    //     }
    //     catch (System.Exception)
    //     {
    //         CherriesEarned.text = "Claim failed";
    //         ClaimButton.gameObject.SetActive(false);
    //         throw;
    //     }
    // }
    public void onDisconnect()
    {
        TokenBalance.text = "Unconnected Wallet";
    }
}