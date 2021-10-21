using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

public class PlayFabUGCManager : MonoBehaviour
{

    public ItemViewController itemController;
    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            PlayFabSettings.staticSettings.TitleId = "C1DF4"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnLoginSuccess(LoginResult result)
    {

        PlayFab.EconomyModels.SearchItemsRequest request = new PlayFab.EconomyModels.SearchItemsRequest();
        request.Filter = "ContentType eq 'Skin'";
        PlayFabEconomyAPI.SearchItems(request, PopulateMarketPlace, OnError);
    }

    void PopulateMarketPlace(PlayFab.EconomyModels.SearchItemsResponse response)
    {
        MarketPlace marketPlace = new MarketPlace();
        foreach (PlayFab.EconomyModels.CatalogItem catalogItem in response.Items)
        {
            ItemData itemData = new ItemData();
            itemData.ItemRating = GetItemRating(catalogItem.Rating);
            itemData.Name = catalogItem.Title.ContainsKey("NEUTRAL") ? catalogItem.Title["NEUTRAL"] : "";
            itemData.Description = catalogItem.Description.ContainsKey("NEUTRAL") ? catalogItem.Description["NEUTRAL"] : "";
            itemData.ThumbnailUrl = catalogItem.Images.Count > 0 ? catalogItem.Images[0].Url : null;
            itemData.Tags = catalogItem.Tags;
            marketPlace.Items.Add(itemData);

        }

        itemController.UpdateMarketPlace(marketPlace);
    }

    private Rating GetItemRating(PlayFab.EconomyModels.Rating rating)
    {
        Rating itemRating = new Rating();
        if(rating != null)
        {
            itemRating = new Rating()
            {
                AvgRating = rating.Average.Value,
                NumberofRatings = rating.TotalCount.Value
            };
        }    

        return itemRating;

    }
    private void OnError(PlayFabError error)
    {
       
        Debug.Log(error);
        
    }
}
