using Exiled.API.Features;

namespace RainbowBroadcasts
{
    public class Main : Plugin<Config>
    {
        public static Main Instance { get; set; }
        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            base.OnDisabled();
        }
    }
}