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
    public class Config : IRocketPluginConfiguration
    {
        public List<EDeathCause> eDeathCauses = new List<EDeathCause>();
        public uint BanTime { get; set; }
        public string PossibleCauses { get; set; }

        public void LoadDefaults()
        {
            PossibleCauses = "SUICIDE";
            PossibleCauses = "BONES";
            PossibleCauses = "FREEZING";
            PossibleCauses = "BURNING";
            PossibleCauses = "INFECTION";
            PossibleCauses = "BREATH";
            PossibleCauses = "VEHICLE";
            PossibleCauses = "SHRED";
            PossibleCauses = "CHARGE";
            PossibleCauses = "SPLASH";
            PossibleCauses = "ACID";
            PossibleCauses = "BOULDER";
            PossibleCauses = "BURNER";
            PossibleCauses = "SPIT";
            PossibleCauses = "SPARK";
            PossibleCauses = "FOOD";
            PossibleCauses = "WATER";
            PossibleCauses = "BLEEDING";
            PossibleCauses = "GUN";
            PossibleCauses = "MEELE";
            PossibleCauses = "ZOMBIE";
            PossibleCauses = "KILL";
            PossibleCauses = "ANIMAL";
            PossibleCauses = "VEHICLE";
            PossibleCauses = "GRANADE";

            eDeathCauses.Add(EDeathCause.SUICIDE);
            BanTime = 3600;
        }
    }
}
