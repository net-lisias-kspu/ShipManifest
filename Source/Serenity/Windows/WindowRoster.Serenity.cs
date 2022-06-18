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
using UnityEngine;

using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;

using ShipManifest.InternalObjects;

namespace ShipManifest.Windows
{
  internal partial class WindowRosterRealization
  {
    private void EditKerbalViewer()
    {
      //GUILayout.Label(SelectedKerbal.IsNew ? "Create Kerbal" : "Edit Kerbal");
      GUILayout.Label(SelectedKerbal.IsNew ? SmUtils.SmTags["#smloc_roster_002"] : SmUtils.SmTags["#smloc_roster_027"]);
      if (SMSettings.EnableKerbalRename)
      {
        GUILayout.BeginHorizontal();
        SelectedKerbal.Name = GUILayout.TextField(SelectedKerbal.Name, GUILayout.MaxWidth(300));
        GUILayout.Label($" - ({SelectedKerbal.Kerbal.experienceTrait.Title})");
        GUILayout.EndHorizontal();
      }
      else
        GUILayout.Label($"{SelectedKerbal.Name} - ({SelectedKerbal.Trait})", SMStyle.LabelStyleBold,
          GUILayout.MaxWidth(300));

      if (!string.IsNullOrEmpty(SMAddon.SaveMessage))
      {
        GUILayout.Label(SMAddon.SaveMessage, SMStyle.ErrorLabelRedStyle);
      }
      if (SMSettings.EnableKerbalRename && SMSettings.EnableChangeProfession)
      {
        DisplaySelectProfession();
      }
      if (Expansions.ExpansionsLoader.IsExpansionAnyKerbalSuitInstalled())
      {
        DisplaySelectSuit(ref _selectedKerbal.Suit);
      }

      // TODO: Realism setting to enable Kerbal Gender Change for existing Kerbals?
      bool isMale = ProtoCrewMember.Gender.Male == SelectedKerbal.Gender;
      GUILayout.BeginHorizontal();
      GUILayout.Label(SmUtils.SmTags["#smloc_roster_017"], GUILayout.Width(85)); // "Gender"
      isMale = GUILayout.Toggle(isMale, ProtoCrewMember.Gender.Male.ToString(), GUILayout.Width(90));
      isMale = GUILayout.Toggle(!isMale, ProtoCrewMember.Gender.Female.ToString());
      SelectedKerbal.Gender = isMale ? ProtoCrewMember.Gender.Female : ProtoCrewMember.Gender.Male;
      GUILayout.EndHorizontal();

      GUILayout.Label(SmUtils.SmTags["#smloc_roster_029"]); // "Courage"
      SelectedKerbal.Courage = GUILayout.HorizontalSlider(SelectedKerbal.Courage, 0, 1, GUILayout.MaxWidth(300));

      GUILayout.Label(SmUtils.SmTags["#smloc_roster_030"]); // "Stupidity"
      SelectedKerbal.Stupidity = GUILayout.HorizontalSlider(SelectedKerbal.Stupidity, 0, 1, GUILayout.MaxWidth(300));

      GUILayout.BeginHorizontal();
      SelectedKerbal.Badass = GUILayout.Toggle(SelectedKerbal.Badass, SmUtils.SmTags["#smloc_roster_031"], GUILayout.Width(90)); // "Badass"
      SelectedKerbal.Veteran = GUILayout.Toggle(SelectedKerbal.Veteran, SmUtils.SmTags["#smloc_roster_035"], GUILayout.Width(90)); // "Veteran"
      GUILayout.EndHorizontal();

      GUILayout.BeginHorizontal();
      if (GUILayout.Button(SmUtils.SmTags["#smloc_roster_004"], GUILayout.MaxWidth(50))) // "Cancel"
      {
        SelectedKerbal = null;
      }
      string label = SmUtils.SmTags["#smloc_roster_028"]; // "Apply"
      //string toolTip = "Applies the changes made to this Kerbal.\r\nDesired Name and Profession will be Retained after save.";
      string toolTip = SmUtils.SmTags["#smloc_roster_tt_006"];
      if (GUILayout.Button(new GUIContent(label, toolTip), GUILayout.MaxWidth(50)))
      {
        if (SMSettings.EnableKerbalRename && SMSettings.EnableChangeProfession)
        {
          if (SelectedKerbal != null) SelectedKerbal.Trait = KerbalProfession.ToString();
        }
        if (SelectedKerbal != null)
        {
          SMAddon.SaveMessage = SelectedKerbal.SubmitChanges();
          GetRosterList();
          if (string.IsNullOrEmpty(SMAddon.SaveMessage))
            SelectedKerbal = null;
        }
      }
      Rect rect = GUILayoutUtility.GetLastRect();
      if (Event.current.type == EventType.Repaint && ShowToolTips)
        ToolTip = SMToolTips.SetActiveToolTip(rect, GUI.tooltip, ref ToolTipActive, 10);
      GUILayout.EndHorizontal();
    }

    private static void DisplaySelectSuit(ref ProtoCrewMember.KerbalSuit suit)
    {
      GUILayout.BeginHorizontal();
      GUILayout.Label(SmUtils.SmTags["#smloc_roster_036"], GUILayout.Width(85)); // "Suit:"

      // Always available
      bool isSet = GUILayout.Toggle(suit == ProtoCrewMember.KerbalSuit.Default, SmUtils.SmTags["#smloc_roster_037"], GUILayout.Width(90)); // "Default"
      if (isSet) suit = ProtoCrewMember.KerbalSuit.Default;

      if (Expansions.ExpansionsLoader.IsExpansionKerbalSuitInstalled(ProtoCrewMember.KerbalSuit.Vintage)) {
        isSet = GUILayout.Toggle(suit == ProtoCrewMember.KerbalSuit.Vintage, SmUtils.SmTags["#smloc_roster_038"], GUILayout.Width(90)); // "Vintage"
        if (isSet) suit = ProtoCrewMember.KerbalSuit.Vintage;
      }
      if (Expansions.ExpansionsLoader.IsExpansionKerbalSuitInstalled(ProtoCrewMember.KerbalSuit.Future)) {
        isSet = GUILayout.Toggle(suit == ProtoCrewMember.KerbalSuit.Future, SmUtils.SmTags["#smloc_roster_039"], GUILayout.Width(90)); // "Future"
        if (isSet) suit = ProtoCrewMember.KerbalSuit.Future;
      }

      GUILayout.EndHorizontal();
    }
  }
}
