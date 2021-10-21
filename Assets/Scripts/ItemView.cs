using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class ItemView : MonoBehaviour
{
    public Button button;
    public Image itemIcon;

    private ItemData itemData;

    public void InitItem(ItemData item, Action<ItemData> buttonCallback)
    {
        this.itemData = item;
        Davinci.get().load(item.ThumbnailUrl).setCached(true).into(itemIcon).start();

        button.onClick.AddListener(() => buttonCallback(itemData));
    }
    //public void DownloadImage(string url)
    //{
    //    StartCoroutine(ImageRequest(url, (UnityWebRequest req) =>
    //    {
    //        if (req.result == UnityWebRequest.Result.ConnectionError)
    //        {
    //            Debug.Log($"{req.error}: {req.downloadHandler.text}");
    //        }
    //        else
    //        {
    //            // Get the texture out using a helper downloadhandler
    //            Texture2D texture = DownloadHandlerTexture.GetContent(req);
    //            // Save it into the Image UI's sprite
    //            itemIcon.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    //        }
    //    }));
    //}

    //IEnumerator ImageRequest(string url, Action<UnityWebRequest> callback)
    //{
    //    using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(url))
    //    {
    //        yield return req.SendWebRequest();
    //        callback(req);
    //    }
    //}

   
}