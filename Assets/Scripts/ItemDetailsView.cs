using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailsView : MonoBehaviour
{
    public Image thumbnail;
    public Text nameText;
    public Text descriptionText;
    public Text tagsText;
    public Text ratingText;

    public void Init(ItemData data)
    {
          
        nameText.text = string.Format("<b>Title</b>    {0}", data.Name);
        descriptionText.text = string.Format("<b>Description</b>    {0}", data.Description);
        tagsText.text = string.Format("<b>Tags</b>    {0}", string.Join(",", data.Tags)); 

        ratingText.text = string.Format("<b>Rating</b>    {0} out of {1} reviews", data.ItemRating.AvgRating, data.ItemRating.NumberofRatings);
        Davinci.get().load(data.ThumbnailUrl).setCached(true).into(thumbnail).start();


    }
}