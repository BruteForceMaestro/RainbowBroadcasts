using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace RainbowBroadcasts
{
    public class Config : IConfig
    {
        [Description("Indicates if plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        [Description("Colors that will be used in the broadcast")]
        public List<string> Colors { get; set; } = new List<string>()
        {
            "red",
            "blue",
            "yellow",
            "purple",
            "#005500"
        };
        [Description("Frequency of color change. Not possible to set float due to base game limitations.")]
        public ushort Frequency { get; set; } = 1;
    }
}