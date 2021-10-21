using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : ScriptableObject
{
    public string Name;
    public string Description;
    public string ThumbnailUrl;
    public List<string> Tags;
    public Rating ItemRating;
}

public class Rating
{
    public float AvgRating;
    public int NumberofRatings;
}
