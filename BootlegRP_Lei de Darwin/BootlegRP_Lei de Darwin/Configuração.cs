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
using Rocket.Core.Plugins;
using Rocket.API;
using Rocket.Unturned;


namespace BootlegRP_Lei_de_Darwin
{
    public class Configuração : IRocketPluginConfiguration
    {
        public bool Sim { get; set; }
        public bool Afogamento { get; set; }
        public bool Suicidio { get; set; }

        public void LoadDefaults()
        {
            Sim = true;
            Afogamento = true;
            Suicidio = true;
        }
    }