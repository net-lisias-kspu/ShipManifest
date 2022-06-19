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

using KSPe.Annotations;
using Toolbar = KSPe.UI.Toolbar;
using GUI = KSPe.UI.GUI;
using GUILayout = KSPe.UI.GUILayout;
using KSP.UI.Screens;
using ShipManifest.Windows;

namespace ShipManifest.APIClients
{
  [KSPAddon(KSPAddon.Startup.MainMenu, true)]
  public class ToolbarController : MonoBehaviour
  {
    internal static ToolbarController Instance = null;
    private KSPe.UI.Toolbar.Toolbar toolbar => KSPe.UI.Toolbar.Controller.Instance.Get<ToolbarController>();

    private delegate void ClickHandler();

    private Toolbar.Button smButton;
    private ClickHandler smButtonClickHandler;

    private Toolbar.Button smSettings;
    private ClickHandler smSettingsClickHandler;

    private Toolbar.Button smRoster;
    private ClickHandler smRosterClickHandler;

    [UsedImplicitly]
    private void Start()
    {
      Instance = this;
      DontDestroyOnLoad(this);
      KSPe.UI.Toolbar.Controller.Instance.Register<ToolbarController>(Version.FriendlyName);
      this.CreateButtons();
    }

    private void CreateButtons()
    {
      if (null == this.smButton)
      { // Setup SM Window button
        this.smButton = Toolbar.Button.Create(this
            , ApplicationLauncher.AppScenes.FLIGHT | ApplicationLauncher.AppScenes.TRACKSTATION
            , Assets.Textures.IconOff_128, Assets.Textures.IconOff_24
            , Version.FriendlyName
          );
        this.smButton.Add(Toolbar.Button.ToolbarEvents.Kind.Active
            , Toolbar.State.Data.Create(Assets.Textures.IconOn_128, Assets.Textures.IconOn_24)
            , Toolbar.State.Data.Create(Assets.Textures.IconOff_128, Assets.Textures.IconOff_24)
          );
        this.smButton.Toolbar.Add(
          Toolbar.Button.ToolbarEvents.Kind.Active
          , new Toolbar.Button.Event(this.OnSmButtonClicked, this.OnSmButtonClicked));
        this.toolbar.Add(this.smButton);
      }

      if (null == this.smSettings)
      { // Setup Settings Button
        this.smSettings = Toolbar.Button.Create(this
            , ApplicationLauncher.AppScenes.SPACECENTER
            , Assets.Textures.IconS_Off_128, Assets.Textures.IconS_Off_24
            , "Ship Manifest Settings Window"
          );
        this.smSettings.Add(Toolbar.Button.ToolbarEvents.Kind.Active
            , Toolbar.State.Data.Create(Assets.Textures.IconS_On_128, Assets.Textures.IconS_On_24)
            , Toolbar.State.Data.Create(Assets.Textures.IconS_Off_128, Assets.Textures.IconS_Off_24)
          );
        this.smSettings.Toolbar.Add(
          Toolbar.Button.ToolbarEvents.Kind.Active
          , new Toolbar.Button.Event(this.OnSmSettingsClicked, this.OnSmSettingsClicked));
        this.toolbar.Add(this.smSettings);
      }

      if (this.smRoster == null)
      { // Setup Roster Button
        this.smRoster = Toolbar.Button.Create(this
            , ApplicationLauncher.AppScenes.SPH | ApplicationLauncher.AppScenes.VAB
            , Assets.Textures.IconR_Off_128, Assets.Textures.IconR_Off_24
            , "Ship Manifest Roster Window"
          );
        this.smRoster.Add(Toolbar.Button.ToolbarEvents.Kind.Active
            , Toolbar.State.Data.Create(Assets.Textures.IconR_On_128, Assets.Textures.IconR_On_24)
            , Toolbar.State.Data.Create(Assets.Textures.IconR_Off_128, Assets.Textures.IconR_Off_24)
          );
        this.smRoster.Toolbar.Add(
          Toolbar.Button.ToolbarEvents.Kind.Active
          , new Toolbar.Button.Event(this.OnSmRosterClicked, this.OnSmRosterClicked));
        this.toolbar.Add(this.smRoster);
      }
    }

    [UsedImplicitly]
    private void OnDestroy()
    {
      this.toolbar.Destroy();
    }

    private void OnSmButtonClicked()
    {
      this.smButtonClickHandler?.Invoke();
    }

    private void OnSmSettingsClicked()
    {
      this.smSettingsClickHandler?.Invoke();
    }

    private void OnSmRosterClicked()
    {
      this.smRosterClickHandler?.Invoke();
    }

    internal void Register(SMAddon currentOwner, WindowRoster.Interface rosterOwner )
    {
      this.smButtonClickHandler = currentOwner.OnSmButtonToggle;
      this.smSettingsClickHandler = currentOwner.OnSmSettingsToggle;
      this.smRosterClickHandler = rosterOwner.OnSmRosterToggle;
    }

    internal void Unregister()
    {
      this.smButtonClickHandler = this.smSettingsClickHandler = this.smRosterClickHandler = null;
    }

    internal void ButtonsActive(bool enableStockToolbar, bool enableBlizzyToolbar)
    {
        // Dummy call for while.
    }
  }
}
