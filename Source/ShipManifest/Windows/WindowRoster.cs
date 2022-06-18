/*
	This file is part of Ship Manifest /L Unleashed
		© 2021-2022 LisiasT : http://lisias.net <support@lisias.net>
		© 2020 micha (mwerle)
		© 2013-2018 PapaJoesSoup

		Ship Manifest /L Unleashed is licensed as follows:

		* CC BY-NC-SA 4.0i : https://creativecommons.org/licenses/by-nc-sa/4.0/

	Ship Manifest /L Unleashed is distributed in the hope that
	it will be useful, but WITHOUT ANY WARRANTY; without even the implied
	warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

*/
using System;
using UnityEngine;
using ShipManifest.Modules;

namespace ShipManifest.Windows
{
  public partial class WindowRoster
  {
		public interface Interface
    {
      string ToolTip { get; set; }
      bool ShowToolTips { get; set; }
      Rect Position { get; set; }
      bool ResetRosterSize { get; }
      bool ShowWindow { get; set; }
      ModKerbal SelectedKerbal { get; set; }
      bool OnCreate { get; set; }
      string Title { get; }

      void Display(int windowId);
      void GetRosterList();
      void ResetKerbalNames();
      void ThawKerbal(string crewName);
    }

    internal static Interface instance = null;
    internal static Interface Instance => instance ?? (instance = Create());
    internal static Interface Create()
    {
      Type type = KSPe.Util.SystemTools.TypeFinder.FindByQualifiedName("ShipManifest.Windows.WindowRosterRealization");
      return (Interface)Activator.CreateInstance(type);
    }
  }
}
