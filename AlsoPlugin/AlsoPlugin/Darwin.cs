using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Provider;
using SDG.Framework;
using Rocket.Core;
using SDG.Unturned;
using Rocket.Unturned.Events;
using SDG.NetTransport;
using SDG.SteamworksProvider;
using Rocket.Unturned.Permissions;
using Rocket.API.Collections;
using Rocket.Unturned.Enumerations;
using Rocket.API.Serialisation;

namespace AlsoPlugin
{
    public class Darwin : RocketPlugin<Config>
    {
        public EDeathCause cause1 { get; set; }
        public List<UnturnedPlayer> Banidos = new List<UnturnedPlayer>();
        public static Darwin Instance { get; set; }
        protected override void Load()
        {
            Instance = this;
            UnturnedPlayerEvents.OnPlayerDeath += this.UnturnedPlayerEvents_OnPlayerDeath;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
        }

        private void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            if (Banidos.Contains(player))
            {
                Banidos.Remove(player);
                player.Ban("Você foi banido por quebrar as leis de Darwin, mais especificamente por morrer: " + Darwin.Instance.Configuration.Instance.eDeathCauses.Find(x => x == cause1).ToString(), Darwin.Instance.Configuration.Instance.BanTime);
            }
        }

        public void UnturnedPlayerEvents_OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, Steamworks.CSteamID murderer)
        {
            if (Darwin.Instance.Configuration.Instance.eDeathCauses.Exists(x => x == cause))
            {
                cause1 = cause;
                Banidos.Add(player);
                UnturnedPlayerEvents.OnPlayerRevive += UnturnedPlayerEvents_OnPlayerRevive1;
            }
        }

        private void UnturnedPlayerEvents_OnPlayerRevive1(UnturnedPlayer player, UnityEngine.Vector3 position, byte angle)
        {
            Banidos.Remove(player);
            player.Ban("Você foi banido por quebrar as leis de Darwin, mais especificamente por morrer: " + Darwin.Instance.Configuration.Instance.eDeathCauses.Find(x => x == cause1).ToString(), Darwin.Instance.Configuration.Instance.BanTime);
            UnturnedPlayerEvents.OnPlayerRevive -= UnturnedPlayerEvents_OnPlayerRevive1;
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerDeath -= this.UnturnedPlayerEvents_OnPlayerDeath;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
            base.Unload();
        }
    }
}
