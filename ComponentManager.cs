using System;
using System.Windows.Forms;

namespace Übung_03

public class ComponentManager : FlowLayoutPanel
{
	public ComponentManager()
	{
		this.AutoScroll = true;
	}

	public void AddComponent(Control component)
	{
		this.Controls.Add(component);	
	}

	public void ClearComponent()
	{
		this.Controls.Clear();
	}
}
