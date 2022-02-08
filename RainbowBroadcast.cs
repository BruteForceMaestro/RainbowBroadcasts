using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using MEC;
using System;

namespace RainbowBroadcasts
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    internal class RainbowBroadcast : ParentCommand
    {
        private int count = 0;
        public RainbowBroadcast() => LoadGeneratedCommands();
        public override string Command => "rainbowbroadcast";

        public override string[] Aliases => new string[] { "rainbowbc", "rbc" };

        public override string Description => "Sends a rainbow broadcast to everyone.";

        public override void LoadGeneratedCommands()
        {
        }
        private readonly string usage = "Use: rainbowbc {text} {time}";
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("rbc"))
            {
                response = "You don't have enough permissions";
                return false;
            }
            if (arguments.Count != 2 || !uint.TryParse(arguments.At(1), out uint value))
            {
                response = usage;
                return false;
            }
            Timing.CallPeriodically(value, Main.Instance.Config.Frequency, () => ShowRainbowBroadcast(arguments.At(0)));
            response = "Sending broadcasts.";
            return true;
        }

        private void ShowRainbowBroadcast(string text)
        {
            Map.Broadcast(Main.Instance.Config.Frequency, $"<color={Main.Instance.Config.Colors[count]}>{text}</color>");
            if (count == Main.Instance.Config.Colors.Count - 1)
            {
                count = 0;
            }
            else
            {
                count++;
            }
        }
    }
}
