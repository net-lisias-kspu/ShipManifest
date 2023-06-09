/*
	This file is part of Ship Manifest /L Unleashed
		© 2021-2023 LisiasT : http://lisias.net <support@lisias.net>
		© 2020 micha (mwerle)
		© 2013-2018 PapaJoesSoup

		Ship Manifest /L Unleashed is licensed as follows:

		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using System;
using System.Collections.Generic;
using UnityEngine;

using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

using ShipManifest.InternalObjects;
using ShipManifest.Modules;


namespace ShipManifest.Windows.Tabs.Control
{
  internal static class TabLight
  {
    internal static string ToolTip = "";
    internal static bool ToolTipActive;
    internal static bool ShowToolTips = true;
    private const float guiRuleWidth = 350;
    private const float guiToggleWidth = 325;

    internal static void Display(Vector2 displayViewerPosition)
    {
      //float scrollX = WindowControl.Position.x + 20;
      //float scrollY = WindowControl.Position.y + 50 - displayViewerPosition.y;
      float scrollX = 20;
      float scrollY = displayViewerPosition.y;

      // Reset Tooltip active flag...
      ToolTipActive = false;
      SMHighlighter.IsMouseOver = false;

      GUILayout.BeginVertical();
      GUI.enabled = true;
      //GUILayout.Label("External Light Control Center ", SMStyle.LabelTabHeader);
      GUILayout.Label(SmUtils.SmTags["#smloc_control_light_000"], SMStyle.LabelTabHeader);
      GUILayout.Label("____________________________________________________________________________________________",
        SMStyle.LabelStyleHardRule, GUILayout.Height(10), GUILayout.Width(guiRuleWidth));
      string step = "start";
      try
      {
        // Display all Lights
        List<ModLight>.Enumerator iLights = SMAddon.SmVessel.Lights.GetEnumerator();
        while (iLights.MoveNext())
        {
          if (iLights.Current == null) continue;
          string label = $"{iLights.Current.Status} - {iLights.Current.Title}";
          bool onState = iLights.Current.IsOn;
          bool newOnState = GUILayout.Toggle(onState, label, GUILayout.Width(guiToggleWidth), GUILayout.Height(40));
          step = "button toggle check";
          if (!onState && newOnState)
            iLights.Current.TurnOnLight();
          else if (onState && !newOnState)
            iLights.Current.TurnOffLight();
          Rect rect = GUILayoutUtility.GetLastRect();
          if (Event.current.type == EventType.Repaint && rect.Contains(Event.current.mousePosition))
            SMHighlighter.SetMouseOverData(rect, scrollY, scrollX, WindowControl.TabBox.height, iLights.Current.SPart, Event.current.mousePosition);
        }
        iLights.Dispose();

        // Display MouseOverHighlighting, if any
        SMHighlighter.MouseOverHighlight();
      }
      catch (Exception ex)
      {
        Log.error("in Light Tab at step {0}", step);
      }
      GUILayout.EndVertical();
    }

    internal static void TurnOnAllLights()
    {
      // iterate thru the hatch parts and open hatches
      List<ModLight>.Enumerator iLights = SMAddon.SmVessel.Lights.GetEnumerator();
      while (iLights.MoveNext())
      {
        if (iLights.Current == null) continue;
        iLights.Current.TurnOnLight();
      }
      iLights.Dispose();
    }

    internal static void TurnOffAllLights()
    {
      // iterate thru the hatch parts and open hatches
      List<ModLight>.Enumerator iLights = SMAddon.SmVessel.Lights.GetEnumerator();
      while (iLights.MoveNext())
      {
        if (iLights.Current == null) continue;
        iLights.Current.TurnOffLight();
      }
      iLights.Dispose();
    }
  }
}
