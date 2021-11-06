/*
	This file is part of Ship Manifest /L Unleashed
		© 2021 Lisias T : http://lisias.net <support@lisias.net>
		© 2020 micha (mwerle)
		© 2013-2018 PapaJoesSoup

		Ship Manifest /L Unleashed is licensed as follows:

		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using System.Collections.Generic;

using UnityEngine;

using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

using ShipManifest.InternalObjects;

namespace ShipManifest.Windows
{
  internal class WindowDebugger
  {
    internal static string Title = $" Ship Manifest -  Debug Console - Ver. {SMSettings.CurVersion}";
    internal static Rect Position = new Rect(0, 0, 0, 0);
    internal static bool ShowWindow;
    internal static string ToolTip = "";
    internal static bool ToolTipActive;
    internal static bool ShowToolTips = true;

    internal static void Display(int windowId)
    {
      Title = $"{SmUtils.SmTags["#smloc_debug_000"]}:  {SMSettings.CurVersion}";

      // set input locks when mouseover window...
      //_inputLocked = GuiUtils.PreventClickthrough(ShowWindow, Position, _inputLocked);

      // Reset Tooltip active flag...
      ToolTipActive = false;

      Rect rect = new Rect(Position.width - 20, 4, 16, 16);
      if (GUI.Button(rect, new GUIContent("", SmUtils.SmTags["#smloc_window_tt_001"]))) // "Close Window"
      {
        ShowWindow = false;
        SMSettings.MemStoreTempSettings();
        ToolTip = "";
      }
      if (Event.current.type == EventType.Repaint && ShowToolTips)
        ToolTip = SMToolTips.SetActiveToolTip(rect, GUI.tooltip, ref ToolTipActive, 10);

      GUILayout.BeginVertical();
      SmUtils.DebugScrollPosition = GUILayout.BeginScrollView(SmUtils.DebugScrollPosition, SMStyle.ScrollStyle,
        GUILayout.Height(300), GUILayout.Width(500));
      GUILayout.BeginVertical();

      List<string>.Enumerator errors = Log.GetEnumerator();
      while (errors.MoveNext())
      {
        if (errors.Current == null) continue;
        GUILayout.TextArea(errors.Current, GUILayout.Width(460));
        
      }
      errors.Dispose();

      GUILayout.EndVertical();
      GUILayout.EndScrollView();

      GUILayout.BeginHorizontal();
      if (GUILayout.Button(SmUtils.SmTags["#smloc_debug_001"], GUILayout.Height(20))) //"Clear log"
      {
        Log.Clear();
      }
      if (GUILayout.Button(SmUtils.SmTags["#smloc_debug_002"], GUILayout.Height(20))) // "Save Log"
      {
        // Create log file and save.
        Log.Save();
      }
      if (GUILayout.Button(SmUtils.SmTags["#smloc_debug_003"], GUILayout.Height(20))) // "Close"
      {
        // Create log file and save.
        ShowWindow = false;
        SMSettings.MemStoreTempSettings();
      }
      GUILayout.EndHorizontal();

      GUILayout.EndVertical();
      GUI.DragWindow(new Rect(0, 0, Screen.width, 30));
      SMAddon.RepositionWindow(ref Position);
    }
  }
}
