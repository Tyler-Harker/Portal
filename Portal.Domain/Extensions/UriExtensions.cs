using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Extensions
{
    public static class UriExtensions
    { 
        public static string? GetPortString(this NavigationManager navigationManager)
        {
            var split = navigationManager.BaseUri.Split(":");
            if(split.Length == 3)
            {
                return ":" + split[2].Remove(split[2].Length - 1, 1);
            }
            return null;
        }
    }
}
