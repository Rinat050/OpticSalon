﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OpticSalon.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string? GetDisplayName(this Enum type)
        {
            return type.GetType().GetField(type.ToString())?.GetCustomAttribute<DisplayAttribute>()?.Name;
        }
    }
}
