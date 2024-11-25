﻿using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;

namespace Bdziam.UI.Model.Utility;

public static class SizeUtility
{
        
    public static string GetIconSize(Size size)
    {
        return size switch
        {
            Size.Small => "1rem",
            Size.Medium => "2rem",
            Size.Large => "3rem",
            Size.ExtraLarge => "4rem",
            _ => "1rem"
        };
    }
    
    public static string GetPadding(Size size)
    {
        return size switch
        {
            Size.Small => "0.5rem",
            Size.Medium => "1rem",
            Size.Large => "2rem",
            Size.ExtraLarge => "3rem",
            _ => "1rem"
        };
    }
    
    public static Dictionary<string,object> GetIconSizeAttributes(Size iconSize = Size.Medium) => new()
            {
                ["style"] = new CssStyleBuilder()
                    .AddStyle("width", GetIconSize(iconSize))
                    .AddStyle("height", GetIconSize(iconSize))
                    .Build(),
                ["width"] = GetIconSize(iconSize),
                ["height"] = GetIconSize(iconSize)
            };
}