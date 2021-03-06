using System;
using System.Collections.Generic;
using HugsLib;

namespace Hospitality
{
    internal class ModBaseHospitality : ModBase
    {
        private static List<Action> TickActions = new List<Action>();

        public static Settings settings;

        private static void Inject()
        {
            var injector = new Hospitality_SpecialInjector();
            injector.Inject();
        }

        public override string ModIdentifier { get { return "Hospitality"; } }

        public override void Initialize()
        {
            Inject();
        }

        public override void DefsLoaded()
        {
            settings = new Settings(Settings);
        }

        public override void Tick(int currentTick)
        {
            foreach (var action in TickActions)
            {
                action();
            }
            TickActions.Clear();
        }

        public static void RegisterTickAction(Action action)
        {
            TickActions.Add(action);
        }
    }
}