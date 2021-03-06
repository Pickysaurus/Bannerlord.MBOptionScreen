﻿using HarmonyLib;

using System;
using System.Reflection;
using System.Xml;

using TaleWorlds.GauntletUI.PrefabSystem;

namespace MCM.Abstractions.Functionality
{
    public sealed class ResourceHandlerWrapper : BaseResourceHandler, IWrapper
    {
        public object Object { get; }
        private MethodInfo? InjectBrushMethod { get; }
        private MethodInfo? InjectPrefabMethod { get; }
        private MethodInfo? InjectWidgetMethod { get; }
        private MethodInfo? MovieRequestedMethod { get; }
        public bool IsCorrect { get; }

        public ResourceHandlerWrapper(object @object)
        {
            Object = @object;
            var type = @object.GetType();

            InjectBrushMethod = AccessTools.Method(type, nameof(InjectBrush));
            InjectPrefabMethod = AccessTools.Method(type, nameof(InjectPrefab));
            InjectWidgetMethod = AccessTools.Method(type, nameof(InjectWidget));
            MovieRequestedMethod = AccessTools.Method(type, nameof(MovieRequested));

            IsCorrect = InjectBrushMethod != null && InjectPrefabMethod != null &&
                        InjectWidgetMethod != null && MovieRequestedMethod != null;
        }

        public override void InjectBrush(XmlDocument xmlDocument) =>
            InjectBrushMethod?.Invoke(Object, new object[] { xmlDocument });
        public override void InjectPrefab(string prefabName, XmlDocument xmlDocument) =>
            InjectPrefabMethod?.Invoke(Object, new object[] { prefabName, xmlDocument });
        public override void InjectWidget(Type widgetType) =>
            InjectWidgetMethod?.Invoke(Object, new object[] { widgetType });
        public override WidgetPrefab? MovieRequested(string movie) =>
            MovieRequestedMethod?.Invoke(Object, new object[] { movie }) as WidgetPrefab;
    }
}