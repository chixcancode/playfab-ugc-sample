using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketPlace : MonoBehaviour
{
    public List<ItemData> Items;
    public MarketPlace()
    {
        this.Items = new List<ItemData>();
    }
}
