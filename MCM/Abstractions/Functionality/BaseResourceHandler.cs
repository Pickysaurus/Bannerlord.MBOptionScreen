﻿using MCM.Utils;

using System;
using System.Xml;

using TaleWorlds.GauntletUI.PrefabSystem;

namespace MCM.Abstractions.Functionality
{
    public abstract class BaseResourceHandler : IDependency
    {
        private static BaseResourceHandler? _instance;
        public static BaseResourceHandler Instance =>
            _instance ??= DI.GetImplementation<BaseResourceHandler, ResourceHandlerWrapper>()!;

        public abstract void InjectBrush(XmlDocument xmlDocument);
        public abstract void InjectPrefab(string prefabName, XmlDocument xmlDocument);
        public abstract void InjectWidget(Type widgetType);
        public abstract WidgetPrefab? MovieRequested(string movie);
    }
}