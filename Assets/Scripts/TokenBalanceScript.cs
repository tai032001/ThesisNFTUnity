using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Thirdweb;
using System.Threading.Tasks;
public class TokenBalanceScript : MonoBehaviour
{
    [SerializeField] private Text TokenBalance;
    [SerializeField] private Text CharacterText;


    void Start()
    {

    }

    public static string ERC_20_Contract = "0x117Ed9670840c7722994098568c2EDd9BdFbeFcC";
    public static string addressWallet;
    public async void getTokenBalance()
    {
        try
        {
            var address = await ThirdwebManager.Instance.SDK.wallet.GetAddress();
            Contract contract = ThirdwebManager.Instance.SDK.GetContract(ERC_20_Contract);
            var data = await contract.ERC20.BalanceOf(address);
            TokenBalance.text = "Token Cherry: " + data.displayValue;
        }
        catch (System.Exception)
        {
            Debug.Log("Error while get balance");
            throw;

        }
    }
    public void onDisconnect()
    {
        TokenBalance.text = "Unconnected Wallet";
        CharacterText.text = "";
    }
}