using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViewController : MonoBehaviour
{
    public Transform inventoryViewParent;
    public Transform infoViewParent;

    private GameObject infoView;
    private GameObject infoViewPrefab;
    private GameObject itemViewPrefab;
    private void Start()
    {
        itemViewPrefab = (GameObject)Resources.Load("ItemButton");
        infoViewPrefab = (GameObject)Resources.Load("ItemDetailsView");
    }

    public void UpdateMarketPlace(MarketPlace marketPlace)
    {
        foreach (var item in marketPlace.Items)
        {
            var itemGO = GameObject.Instantiate(itemViewPrefab, inventoryViewParent);
            itemGO.GetComponent<ItemView>().InitItem(item, CreateInfoView);
        }

    }


    private void CreateInfoView(ItemData data)
    {
        if (infoView != null)
        {
            Destroy(infoView);
        }

        infoView = GameObject.Instantiate(infoViewPrefab, infoViewParent);
        infoView.GetComponent<ItemDetailsView>().Init(data);
    } 
}