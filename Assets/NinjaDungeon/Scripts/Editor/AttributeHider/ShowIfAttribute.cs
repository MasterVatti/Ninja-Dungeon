using System;
using UnityEngine;

namespace EditorTools.AttributeHider
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public ActionOnConditionFail Action { get; }
        public ConditionOperator Operator { get; }
        public string[] Conditions { get; }

        public ShowIfAttribute(ActionOnConditionFail action, ConditionOperator conditionOperator,
            params string[] conditions)
        {
            Action = action;
            Operator = conditionOperator;
            Conditions = conditions;
        }
    }
}
