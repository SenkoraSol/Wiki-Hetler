using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


public partial class ItemWikiRandom
{
    public List<Item> Items { get; set; }
}

public partial class Item
{
    public string Title { get; set; }
    public long PageId { get; set; }
    public long Rev { get; set; }
    public Guid Tid { get; set; }
    public long Namespace { get; set; }
    public long UserId { get; set; }
    public string UserText { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string Comment { get; set; }
    public List<string> Tags { get; set; }
    public List<object> Restrictions { get; set; }
    public string PageLanguage { get; set; }
    public bool Redirect { get; set; }
}