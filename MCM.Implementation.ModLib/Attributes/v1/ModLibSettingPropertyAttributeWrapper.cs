﻿using MCM.Abstractions.Settings.Definitions;

using TaleWorlds.Localization;

namespace MCM.Implementation.ModLib.Attributes.v1
{
    public sealed class ModLibSettingPropertyAttributeWrapper :
        IPropertyDefinitionBool,
        IPropertyDefinitionWithMinMax,
        IPropertyDefinitionWithEditableMinMax
    {
        public string DisplayName { get; }
        public int Order { get; }
        public bool RequireRestart { get; }
        public string HintText { get; }
        public decimal MinValue { get; }
        public decimal MaxValue { get; }
        public decimal EditableMinValue { get; }
        public decimal EditableMaxValue { get; }

        public ModLibSettingPropertyAttributeWrapper(object @object)
        {
            var type = @object.GetType();

            DisplayName = new TextObject(type.GetProperty("DisplayName")?.GetValue(@object) as string ?? "ERROR", null).ToString();
            HintText = new TextObject(type.GetProperty("HintText")?.GetValue(@object) as string ?? "ERROR", null).ToString();
            Order = -1;
            RequireRestart = true;

            MinValue = (decimal) (type.GetProperty("MinValue")?.GetValue(@object) as float? ?? 0);
            MaxValue = (decimal) (type.GetProperty("MaxValue")?.GetValue(@object) as float? ?? 0);
            EditableMinValue = (decimal) (type.GetProperty("EditableMinValue")?.GetValue(@object) as float? ?? 0);
            EditableMaxValue = (decimal) (type.GetProperty("EditableMaxValue")?.GetValue(@object) as float? ?? 0);
        }
    }
}