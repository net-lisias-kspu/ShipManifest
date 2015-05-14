﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;
using ConnectedLivingSpace;

namespace ShipManifest
{
    internal static class WindowManifest
    {
        #region Manifest Window - Gui Layout Code

        internal static string ToolTip = "";
        internal static bool ToolTipActive = false;
        internal static bool ShowToolTips = Settings.ManifestToolTips;

        // Ship Manifest Window
        // This window displays options for managing crew, resources, and flight checklists for the focused vessel.
        private static Vector2 SMScrollViewerPosition = Vector2.zero;
        private static Vector2 ResourceScrollViewerPosition = Vector2.zero;
        internal static void Display(int windowId)
        {
            // Reset Tooltip active flag...
            ToolTipActive = false;
            ShowToolTips = Settings.ManifestToolTips;

            GUIContent label = new GUIContent("", "Close Window");
            if (SMAddon.crewXfer || SMAddon.XferOn)
            {
                label = new GUIContent("", "Action in progress.  Cannot close window");
                GUI.enabled = false;
            }
            Rect rect = new Rect(296, 4, 16, 16);
            if (GUI.Button(rect, label))
            {
                SMAddon.OnSMButtonToggle();
                ToolTip = "";
            }
            if (Event.current.type == EventType.Repaint && ShowToolTips == true)
                ToolTip = Utilities.SetActiveTooltip(rect, Settings.ManifestPosition, GUI.tooltip, ref ToolTipActive, 0, 0);
            GUI.enabled = true;
            try
            {
                GUILayout.BeginVertical();
                SMScrollViewerPosition = GUILayout.BeginScrollView(SMScrollViewerPosition, GUILayout.Height(100), GUILayout.Width(300));
                GUILayout.BeginVertical();

                if (SMAddon.smController.IsPreLaunch)
                {
                    PreLaunchGUI();
                }

                // Now the Resource Buttons
                ResourceButtonList();

                GUILayout.EndVertical();
                GUILayout.EndScrollView();
                string resLabel = "No Resource Selected";
                if (SMAddon.smController.SelectedResources.Count == 1)
                    resLabel = SMAddon.smController.SelectedResources[0];
                else if (SMAddon.smController.SelectedResources.Count == 2)
                    resLabel = "Multiple Resources selected";
                GUILayout.Label(string.Format("{0}", resLabel), GUILayout.Width(300), GUILayout.Height(20));

                // Resource Details List Viewer
                ResourceDetailsViewer();

                GUILayout.BeginHorizontal();

                var settingsStyle = Settings.ShowSettings ? SMStyle.ButtonToggledStyle : SMStyle.ButtonStyle;
                if (GUILayout.Button("Settings", settingsStyle, GUILayout.Height(20)))
                {
                    try
                    {
                        Settings.ShowSettings = !Settings.ShowSettings;
                        if (Settings.ShowSettings)
                        {
                            // Store settings in case we cancel later...
                            Settings.StoreTempSettings();
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.LogMessage(string.Format(" opening Settings Window.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
                    }
                }

                var rosterStyle = Settings.ShowRoster ? SMStyle.ButtonToggledStyle : SMStyle.ButtonStyle;
                if (GUILayout.Button("Roster", rosterStyle, GUILayout.Height(20)))
                {
                    try
                    {
                        Settings.ShowRoster = !Settings.ShowRoster;
                        if (!Settings.ShowRoster)
                        {
                            WindowRoster.SelectedKerbal = null;
                            WindowRoster.ToolTip = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Utilities.LogMessage(string.Format(" opening Roster Window.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
                    }
                }

                var controlStyle = Settings.ShowControl ? SMStyle.ButtonToggledStyle : SMStyle.ButtonStyle;
                if (GUILayout.Button("Control", controlStyle, GUILayout.Height(20)))
                {
                    try
                    {
                        Settings.ShowControl = !Settings.ShowControl;
                    }
                    catch (Exception ex)
                    {
                        Utilities.LogMessage(string.Format(" opening Control Window.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                GUI.DragWindow(new Rect(0, 0, Screen.width, 30));
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(string.Format(" in Ship Manifest Window.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
            }
        }

        #endregion

        #region Ship Manifest Window Gui components

        private static void PreLaunchGUI()
        {
            try
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button(string.Format("Fill Crew"), SMStyle.ButtonStyle, GUILayout.Width(130), GUILayout.Height(20)))
                {
                    SMAddon.smController.FillVesselCrew();
                }
                if (GUILayout.Button(string.Format("Empty Crew"), SMStyle.ButtonStyle, GUILayout.Width(130), GUILayout.Height(20)))
                {
                    SMAddon.smController.EmptyVesselCrew();
                }
                GUILayout.EndHorizontal();

                if (Settings.EnablePFResources)
                {
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button(string.Format("Fill Resources"), SMStyle.ButtonStyle, GUILayout.Width(130), GUILayout.Height(20)))
                    {
                        SMAddon.smController.FillVesselResources();
                    }
                    if (GUILayout.Button(string.Format("Empty Resources"), SMStyle.ButtonStyle, GUILayout.Width(130), GUILayout.Height(20)))
                    {
                        SMAddon.smController.EmptyVesselResources();
                    }
                    GUILayout.EndHorizontal();
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(string.Format(" in PreLaunchGUI.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
            }
        }

        private static void ResourceButtonList()
        {
            try
            {
                foreach (string resourceName in SMAddon.smController.PartsByResource.Keys)
                {
                    GUILayout.BeginHorizontal();
                    int width = 265;
                    if ((!Settings.RealismMode || SMAddon.smController.IsPreLaunch) && resourceName != "Crew" && resourceName != "Science")
                        width = 175;

                    string DisplayAmounts = Utilities.DisplayVesselResourceTotals(resourceName);
                    var style = SMAddon.smController.SelectedResources.Contains(resourceName) ? SMStyle.ButtonToggledStyle : SMStyle.ButtonStyle;
                    if (GUILayout.Button(string.Format("{0}", resourceName + DisplayAmounts), style, GUILayout.Width(width), GUILayout.Height(20)))
                    {
                        ResourceButtonToggled(resourceName);
                    }
                    if ((!Settings.RealismMode || SMAddon.smController.IsPreLaunch) && resourceName != "Crew" && resourceName != "Science")
                    {
                        if (GUILayout.Button(string.Format("{0}", "Dump"), SMStyle.ButtonStyle, GUILayout.Width(45), GUILayout.Height(20)))
                        {
                            SMAddon.smController.DumpResource(resourceName);
                        }
                        if (GUILayout.Button(string.Format("{0}", "Fill"), SMStyle.ButtonStyle, GUILayout.Width(35), GUILayout.Height(20)))
                        {
                            SMAddon.smController.FillResource(resourceName);
                        }
                    }
                    GUILayout.EndHorizontal();
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(string.Format(" in ResourceButtonList.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
            }
        }

        private static void ResourceButtonToggled(string resourceName)
        {
            try
            {
                if (!SMAddon.crewXfer && !SMAddon.XferOn)
                {
                    // First, lets clear any highlighting...
                    SMAddon.ClearResourceHighlighting(SMAddon.smController.SelectedResourcesParts);

                    // Now let's update our lists...
                    if (!SMAddon.smController.SelectedResources.Contains(resourceName))
                    {
                        // now lets determine what to do with selection
                        if (resourceName == "Crew" || resourceName == "Science" || resourceName == "ElectricCharge")
                        {
                            SMAddon.smController.SelectedResources.Clear();
                            SMAddon.smController.SelectedResources.Add(resourceName);
                        }
                        else
                        {
                            if (SMAddon.smController.SelectedResources.Contains("Crew") || SMAddon.smController.SelectedResources.Contains("Science") || SMAddon.smController.SelectedResources.Contains("ElectricCharge"))
                            {
                                SMAddon.smController.SelectedResources.Clear();
                                SMAddon.smController.SelectedResources.Add(resourceName);
                            }
                            else if (SMAddon.smController.SelectedResources.Count > 1)
                            {
                                SMAddon.smController.SelectedResources.RemoveRange(0, 1);
                                SMAddon.smController.SelectedResources.Add(resourceName);
                            }
                            else
                                SMAddon.smController.SelectedResources.Add(resourceName);
                        }
                    }
                    else if (SMAddon.smController.SelectedResources.Contains(resourceName))
                    {
                        SMAddon.smController.SelectedResources.Remove(resourceName);
                    }

                    // Now, refresh the resources parts list
                    SMAddon.smController.GetSelectedResourcesParts();

                    // now lets reconcile the selected parts based on the new list of resources...
                    ReconcileSelectedXferParts(SMAddon.smController.SelectedResources);

                    // Now lets update the Xfer Objects...
                    SMAddon.smController.ResourcesToXfer.Clear();
                    foreach (string resource in SMAddon.smController.SelectedResources)
                    {
                        // Lets create a Xfer Object for managing xfer options and data.
                        ModXferResource modResource = new ModXferResource(resource);
                        modResource.sXferAmount = ModXferResource.CalcMaxResourceXferAmt(SMAddon.smController.SelectedPartsSource, SMAddon.smController.SelectedPartsTarget, resource);
                        modResource.tXferAmount = ModXferResource.CalcMaxResourceXferAmt(SMAddon.smController.SelectedPartsTarget, SMAddon.smController.SelectedPartsSource, resource);
                        SMAddon.smController.ResourcesToXfer.Add(modResource);
                    }

                    // Now, based on the resourceselection, do we show the Transfer window?
                    if (SMAddon.smController.SelectedResources.Count > 0)
                        Settings.ShowTransferWindow = true;
                    else
                        Settings.ShowTransferWindow = false;
                }
            }
            catch (Exception ex)
            {
                Utilities.LogMessage(string.Format(" in WindowManifest.ResourceButtonToggled.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
            }
        }

        private static void ReconcileSelectedXferParts(List<string> resourceNames)
        {
            if (resourceNames.Count > 0)
            {
                List<Part> newSources = new List<Part>();
                List<Part> newTargets = new List<Part>();
                SMAddon.ClearPartsHighlight(SMAddon.smController.SelectedPartsSource);
                foreach (Part part in SMAddon.smController.SelectedPartsSource)
                {
                    if (resourceNames.Count > 1)
                    {
                        if (part.Resources.Contains(resourceNames[0]) && part.Resources.Contains(resourceNames[1]))
                            newSources.Add(part);
                    }
                    else if (part.Resources.Contains(resourceNames[0]))
                        newSources.Add(part);
                }

                SMAddon.ClearPartsHighlight(SMAddon.smController.SelectedPartsTarget);
                foreach (Part part in SMAddon.smController.SelectedPartsTarget)
                {
                    if (resourceNames.Count > 1)
                    {
                        if (part.Resources.Contains(resourceNames[0]) && part.Resources.Contains(resourceNames[1]))
                            newTargets.Add(part);
                    }
                    else if (part.Resources.Contains(resourceNames[0]))
                        newTargets.Add(part);
                }
                SMAddon.smController.SelectedPartsSource.Clear();
                SMAddon.smController.SelectedPartsSource = newSources;
                SMAddon.smController.SelectedPartsTarget.Clear();
                SMAddon.smController.SelectedPartsTarget = newTargets;
            }
            else
            {
                SMAddon.smController.SelectedPartsSource.Clear();
                SMAddon.smController.SelectedPartsTarget.Clear();
            }
        }

        private static void ResourceDetailsViewer()
        {
            try
            {
                ResourceScrollViewerPosition = GUILayout.BeginScrollView(ResourceScrollViewerPosition, GUILayout.Height(100), GUILayout.Width(300));
                GUILayout.BeginVertical();

                if (SMAddon.smController.SelectedResources.Count > 0)
                {
                    foreach (Part part in SMAddon.smController.SelectedResourcesParts)
                    {
                        if (!SMAddon.smController.SelectedResources.Contains("Crew") && !SMAddon.smController.SelectedResources.Contains("Science"))
                        {
                            GUIStyle noWrap = SMStyle.LabelStyleNoWrap;
                            GUILayout.Label(string.Format("{0}", part.partInfo.title), noWrap, GUILayout.Width(265), GUILayout.Height(18));
                            GUIStyle noPad = SMStyle.LabelStyleNoPad;
                            foreach (string resource in SMAddon.smController.SelectedResources)
                                GUILayout.Label(string.Format(" - {0}:  ({1}/{2})", resource, part.Resources[resource].amount.ToString("######0.####"), part.Resources[resource].maxAmount.ToString("######0.####")), noPad,GUILayout.Width(265), GUILayout.Height(16));
                        }
                        else if (SMAddon.smController.SelectedResources.Contains("Crew"))
                        {
                            GUILayout.BeginHorizontal();
                            GUILayout.Label(string.Format("{0}, ({1}/{2})", part.partInfo.title, part.protoModuleCrew.Count.ToString(), part.CrewCapacity.ToString()), GUILayout.Width(265), GUILayout.Height(20));
                            GUILayout.EndHorizontal();
                        }
                        else if (SMAddon.smController.SelectedResources.Contains("Science"))
                        {
                            int ScienceCount = 0;
                            foreach (PartModule pm in part.Modules)
                            {
                                if (pm is ModuleScienceContainer)
                                    ScienceCount += ((ModuleScienceContainer)pm).GetScienceCount();
                                else if (pm is ModuleScienceExperiment)
                                    ScienceCount += ((ModuleScienceExperiment)pm).GetScienceCount();
                            }
                            GUILayout.BeginHorizontal();
                            GUILayout.Label(string.Format("{0}, ({1})", part.partInfo.title, ScienceCount.ToString()), GUILayout.Width(265));
                            GUILayout.EndHorizontal();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!SMAddon.frameErrTripped)
                {
                    Utilities.LogMessage(string.Format(" in WindowManifest.ResourceDetailsViewer.  Error:  {0} \r\n\r\n{1}", ex.Message, ex.StackTrace), "Error", true);
                    SMAddon.frameErrTripped = true;
                }
            }
            GUILayout.EndVertical();
            GUILayout.EndScrollView();
        }

        #endregion
    }
}