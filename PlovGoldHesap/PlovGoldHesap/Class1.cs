using Rocket.API;
using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlovGoldHesap
{
    public class Class1:RocketPlugin
    {
        public override TranslationList DefaultTranslations => new TranslationList()
        {
            {"This_server_requires_gold_upgrade","You do not have a gold account, you cannot login to the server"}
        };

        protected override void Load()
        {
            U.Events.OnPlayerConnected += Giriş;
        }

        private void Giriş(UnturnedPlayer player)
        {
            if (!player.IsPro)
               player.Kick(DefaultTranslations.Translate("This_server_requires_gold_upgrade"));
        }

        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Giriş;
        }
    }
    
}
