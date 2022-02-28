using UnityEngine;

public class NameAttribute : PropertyAttribute
{
	public string name;

	public NameAttribute(string name)
	{
		this.name = name;
	}
}