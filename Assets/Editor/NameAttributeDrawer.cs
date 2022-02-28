using UnityEditor;
using UnityEngine;

namespace Platformer.Inspector
{
	[CustomPropertyDrawer(typeof(NameAttribute))]
	public class NameAttributeDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			if (this.attribute is NameAttribute na)
			{
				label.text = na.name;
				
				EditorGUI.BeginProperty(position, label, property);
				
				position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
				
				EditorGUI.PropertyField(position, property, GUIContent.none);
				EditorGUI.EndProperty();
			}
		}
	}
}