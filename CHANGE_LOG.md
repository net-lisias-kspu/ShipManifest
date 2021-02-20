# ShipManifest :: Change Log

* 2016-0515: 5.1.0.0 (PapaJoesSoup) for KSP 1.1.3
	+ Version 5.1.0.0 - Release 14 May, 2016 - KSP 1.1.2 Compatability Update
		- New:  Updated mod to support KSP 1.1.2.
		- New:  Updated screen maeeages to use new object model.
* 2016-0405: 5.0.9.0 (PapaJoesSoup) for KSP 1.1 PRE-RELEASE
	+ Version 5.0.9.0 - Release 05 Apr, 2016 - KSP 1.1 Compatability Update *\* PreRelease 
		- New:  Updated code to run on KSP 1.1
		- New:  Modified screen message displays to account for channges to the object model.  SM screen messages are wip.
* 2016-0315: 5.0.1.0 (PapaJoesSoup) for KSP 1.0.5
	+ Version 5.0.1.0 - Release 14 Mar, 2016 - Bug fixes and APIs
		- New:  Removed DFInterface.dll.  Added Reflection based Wrapper class source code for integration with DeepFreeze.
		- New:  Removed SMInterface.dll.   Replaced by SMWrapper, which is also a reflection based wrapper for developer use with SM.
		- Fixed:  Crew movement issues with DeepFreeze.
		- Fixed:  Roster Window does not display correctly with DeepFreeze installed.
		- Fixed:  EVA kerbals causing a null ref bug and duplicating kerbals.  This fix requires the latest version of Deepfreeze (V0.20.4.0) if you use it with SM.
* 2016-0307: 5.0.0.1 (PapaJoesSoup) for KSP 1.0.5
	+ Version 5.0.0.1 - Release 07 Mar, 2016 - Massive Refactoring Edition. NEW! Realism Mode - Multiple simultaneous transfers & dumps.
		- New:  Added Volume controls in the sound tab of the Settings Window.   They had long been in the settings file, but not in the UI. I don't know why...
		- New:  Science Transfers:  Added ability to process unprocessed in science labs. Git Issue #14
		- Fixed:  Windows disappear on settings save.
		- Fixed:  Windows disappear on window resolution changes.
		- Fixed:  Vessel Transfers were not visible.
		- Fixed:  Transfers were not behaving properly.
		- Fixed:  Transfer sounds continue playing afer transfer complete.
		- Fixed:  Science Tooltips (and others) scrolling off screen on long lists.  Git Issue #18
* 2016-0222: 5.0.0.0 (PapaJoesSoup) for KSP 1.0.5
	+ Version 5.0.0.0 - Release 22 Feb, 2016 - Massive Refactoring Edition. NEW! Realism Mode - Multiple simultaneous transfers & dumps.
		- New:  Added ability queue transfers in realism mode.  you may now start and stop multiple transfers and or dumps simultaneously,
			- with the Vessel, Docked Vessels, individual parts or a selected group of parts.  Fuel Depot anyone?
		- New:  Added ability to dump resources in flight in realism mode.  Dump process follows flow rate rules.  Dumps cannot be stopped/reversed.
			- per forum discussions, this process is assumed to impart a zero thrust component upon the vessel.
		- New:  Massive refactor and reorgainization of code (nothing was left untouched).
			- A tremendous amount of work for very little visible effect except maybe performance :). Sets the foundation for easier to manage/enhance code.
		- New:  Added build package automation and distribution.
		- New:  Removed need for DFInterface.dll.  Now using new reflection class method for soft dependency to DeepFreeze.
		- Fixed:  In realism Mode, during Preflight, Fill and dump kerbals vessel wide was enabled.   Now disabled when Realism is on.
		- Fixed:  Corrected nested control displays in settings.
		- Fixed:  Corrected Errors with tooltip displays and tooltip settings.  Tooltips would show on certain windows when disabled in settings.
		- Fixed:  Corrected staging error where SM cannot be displayed during launch.
* 2015-1113: 4.4.2.0 (PapaJoesSoup) for KSP 1.0.5
	+ Version 4.4.2.0 - Release 12 Nov, 2015 - KSP 1.0.5 Edition.
		- New:  Native Kerbal Renaming and Profession Management!  The old hash hack is gone!
			- KSP 1.0.5 now supports native kerbal profession managment, so kerbal profession now saves to game save.
			- Updated SM to use new trait attribute of the kerbal object.  Also supports old game saves.
			- Cleans up old game save automatically, if profession management is ON in settings (now the default)
		- New:  Added Crew Dump/Fill at part level in Transfer Window, when vessel is in a recoverable state and realism is off.
		- New:  based on feedback, expanded science tooltips to be more useful.
		- Fixed:  Correct a window position loading error on MAC machines.
		- Fixed:  Correct issues and deeper integration with DeepFreeze.  (Thanks JPLRepo!)
		- Fixed:  Tooltip display issues with screen boundary
* 2015-0709: 4.4.1.1 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.4.1.1 - Release 09 July, 2015 - Tooltips & Science Xfer Improvements.
		- Fixed:  Correct a display error with science tooltip when an experiment result key is not found.  Now displays the default key's data.
* 2015-0706: 4.4.1.0 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.4.1.0 - Release 05 July, 2015 - Tooltips & Science Xfer Improvements.
		- New:  Refactored and expanded Tooltips.  Changed background, positioning, anchor points, font styles & colors for better readability.  Added more tooltips to various windows and tabs.
		- New:  Added Control Window Tooltip control to settings.  If control window Tooltips is off, all tab tooltip settings are disabled.
		- New:  Added linkage of Control Window Tab Tooltip settings to the Control Window ToolTip control.  They now act as children.
		- New:  Added Detail support to Experiments.  Added greater detail to science tooltips.  Cleaned up horizontal scroll behavior and layout.
		- New:  Added labels to button headers in Roster Window.
		- New:  Added 2 additional Roster List Filters.  "Assigned" and "Frozen".
		- New:  Added active window screen edge managment.  No more positioning windows beyond the screen edge when moving.
		- Fixed:  Control window close button (upper right) did not display tooltip.
		- Fixed:  Some Roster window action buttons have incorrect text when in Space Center.
* 2015-0701: 4.4.0.3 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.4.0.3 - Release 01 July, 2015 - Docked Vessel Transfers Edition.
		- New:  Science transfers now allow individual report transfers from a science container.  You can transfer all or any now. Added an Expand/collapse button for clean display.
		- New:  Altered stock Transfer messaging system to show success messages near portraits.  Cleaner look.
		- New:  General clean up of button displays to prevent overflowing of text.
		- Fixed:  When Transferring crew, the user can switch to IVA, causing potential camera issues.  Switching to IVA is now prevented and a message is displayed near portraits.
		- Fixed:  Saving Settings sometimes does not "stick"  When opening and closing settings without saving in Space Center, default values can overwrite saved values.
		- Fixed:  Stock Crew transfer were not being handled correctly, and transfer fail message was always being shown.
* 2015-0625: 4.4.0.2 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.4.0.2 - Release 24 June, 2015 - Docked Vessel Transfers Edition.
		- New:  Added StockCrewXferOverride flag to SMInterface
		- New:  Added check for full DeepFreezer when Stock Transfer Initiated and Override is On.  Ignore event if Freezer is full, and allow DeepFreeze to handle it.
* 2015-0623: 4.4.0.1 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.4.0.1 - Release 23 June, 2015 - Docked Vessel Transfers Edition.
		- Fixed:  When switching vessels while in MapView with Crew Selected and CLS installed and enabled, errors are generated in log during transition.
		- Fixed:  With the releae of DeepFreeze 0.16, freeze and thaw commands from Roster Window no longer work and cause errors.
* 2015-0617: 4.4.0.0 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.4.0.0 - Release 17 June, 2015 - Docked Vessel Transfers Edition.
		- New:  Added ability to transfer, dump/fill resources by Docked vessel.  Multi resource, Docked Vessel(s) <-> Docked vessel(s), Docked Vessel(s) <-> Part(s), and Part(s) <-> Part(s) transfers are now possible.  Huge flexibility.
		- New:  Highlighting Refactoring.  Docked Vessel highlighting, on mouseover cleanup, and standardized mouseover highlighting model.
		- New:  Opened up SM to allow operation in MapView while in flight.  All features work, and Toolbar button is displayed while in MapView during flight.
* 2015-0615: 4.3.1.0 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.3.1.0 - Release 15 June, 2015 - GUI Skins, DeepFreeze & Bugs Edition.
		- New:  Tightened Integration with DeepFreeze by adding DF Interface component and simplifying Frozen Kerbal display and detection...
		- New:  Added ability to Freeze/Thaw Kerbals in  DeepFreeze Container via Roster window.  Works only when a freezer is part of the active vessel and contains kerbals.
		- New:  Added New GUI Skin: Unity Default.  Selectable in Settings Config Tab and takes effect immediately.
		- New:  Updated Roster display to improve general layout and readability.
		- New:  Added Mods Tab to Settings Window.  Displayes Installed Mods/Assemblies.
		- Fixed:  Bug in settings.  When cancelling or saving changes in Space Center, Settings Icon does not revert on toolbar.
		- Fixed:  Bug with KIS compatability.  When transferring Kerbals with inventory, a race condition occurs with OnCrewTransferred Event handler and causes errors.
			- Added switch in SMSetting.dat to allow disabling onCrewTransferred Event call if KIS still is causing issues.
		- Fixed:  Bug in Multi Part transfers.  Transfers sometimes still hang.  Added check for maxAmount to Transfer, and a flag for transfer in progress to allow Stop button to remain visible until completion...
* 2015-0608: 4.3.0.2 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.3.0.2 - Release 08 June, 2015 - Crew, Interfaces, & Refactoring Edition.
		- New:  Cleaned up highlighting when undocking events occur to turn off highlighting on vessel parts/vessels that become detatched...
		- Fixed:  Bug in settings.  When disabling Crew in setting, if crew was selected, Highligting does not turn off.
		- Fixed:  Bug in Settings.  When in Highlighting Tab, "Highlight only Source/Target parts" and "Enable CLS Highlighting" should act like radio buttons but do not.
		- Fixed:  Under certain circumstances, Highlighting woud not be completely cleared when turned off If crew was selected and CLS was enabled.
* 2015-0606: 4.3.0.1 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.3.0.1 - Release 06 June, 2015 - Crew, Interfaces, & Refactoring Edition.
		- New:  Refactored Resource transfers to improve overall transfer speed, flow & "feel".  Lag was causing issues on larger vessels.
		- New:  Refactored Vessel update methods to properly udate various part lists if vessel changes occur while SM windows are open (undocking, etc.).  Now various windows properly refresh.
		- Fixed:  Bug in multi-part transfers that allowed continued transfers when a transfer is initiated and then you undock a vessel from a station.
		- Fixed:  Bug in Crew Transfers that allowed continued transfers when a crew transfer is initiated and then you undock a vessel from a station.
* 2015-0605: 4.3.0.0 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.3.0.0 - Release 04 June, 2015 - Crew, Interfaces, & Refactoring Edition.
		- New:  Refactored Crew transfers into separate class to improve visibility and state management.
		- New:  Crew transfers (part to part & seat to seat) now show both kerbals involved as moving, when a kerbal swap occurs.
		- New:  Added DeepFreeze mod support for handling/viewing frozen kerbals. No more xferring frozen kerbals, and Roster Window now shows frozen kerbals.
		- New:  Added SMInterface.dll for other mods to detect Crew xfers in progress and act accordingly.
		- New:  Add onCrewTransferred Event trigger to be consistent with Stock Crew Transfers and to support KIS inventory movement when crew transfers occur.
		- New:  Added Kerbal Filter for Roster Window:  All, vessel, Available, Dead/Missing.  Vessel filter is omitted when in Space Center.
		- New:  Refactoring - moved window vars from Settings into window level code.
		- New:  Refactoring - Added InstalledMods static class to centralize mod assembly detection and soft dependencies.
		- New:  Refactoring - Altered Settings Save to segregate Hidden settings for ease of identification by users.
		- Fixed:  Bug in multi-part transfers that lock transfer in run state, with no progress.  Gave loops timeouts, and relaxed the resolution of the calculation to allow for rounding errors.
		- Fixed:  Bug in Crew Transfer.  When transferring a crew member to a full part with realism off, the crew member does not swap and disappears...
		- Fixed:  Bug in Crew Transfer with CLS installed.  First transfer works fine, subsequent xfers fail, and Transfer is stuck in moving...
* 2015-0514: 4.2.1.1 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.2.1.1 - Release 14 May, 2015 - Highlighting Updates Edition Bug Fix.
		- Fixed:  In Settings, if CLS is not installed, or CLS is disabled, changing the Enable Highlighting setting causes some buttons below it to become disabled.
* 2015-0513: 4.2.1.0 (PapaJoesSoup) for KSP 0.90.
	+ Version 4.2.1.0 - Release 13 May, 2015 - Highlighting Updates Edition.
		- New:  Added mouseover part highlighting on Transfer Window part Selection buttons.
		- New:  Revised mousover highlighting to use new edge highlighting methods introduced in KSP 0.90.  Improves visibility of highlighted parts.
		- New:  Added configuration switch to enable/disable mouseover edge highlighting, if performance is affected or behavior is not desired.
		- Fixed:  When using Mod Admin, SM generates and error, and SMSettings file is not created, as PluginData folder is deleted (compatability issue).
		- Fixed:  When in Preflight or Flight and Realism Off, Selecting a single fluid/gaseous resource causes Transfer Window display issues (Found during Wiki creation).  Bug introduced in 4.2.0.0
		- Fixed:  When performing a Crew Transfer in SM with Realism on, it is possible to perform a stock transfer during the Crew transfer process if Override is off, and potentially create a ghost kerbal.
		- Fixed:  When removing/adding crew to a vessel in pre-flight, vessel "remembers" professions available when scene loads.  A scene change causes correct professions to be initialized. Possible exploit.
* 2015-0506: 4.2.0.2 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.2.0.2 - Release 05 May, 2015 - Transfers Expansion Edtion bug fixes.
		- Fixed:  Science Transfer broken.  Bug introduced with version 4.2.0.0
	+ Added Wiki to Github
* 2015-0505: 4.2.0.1 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.2.0.1 - Release 04 May, 2015 - Transfers Expansion Edtion bug fixes.
		- Fixed:  When realism is off and override Stock crew Xfers is on, transfers cause a flickering portrait and do not complete.
		- Fixed:  In Roster, Gender is correctly displayed, but changing a Kerbal's Gender results in the opposite gender being saved.
* 2015-0504: 4.2.0.0 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.2.0.0 - Release 03 May, 2015 - Transfers Expansion Edtion. Multi-Resource & Multi-Part Xfers.
		- New: You can now "link" 2 resources together simply by clicking on a Second Resource.
		- New: You can now link multiple parts in the Transfer window, and move resources from 1:N, N:N and N:1 parts.
		- New: Added Kerbal Gender Management in Roster Window.
		- New: Added Revert profession renaming feature to Roster for removing the ascii "1"s from game save.  For mod compatibility.
		- New: Changed config file from xml to json style.  No more spamming the KSP debug log.
		- New: Cleaned up science transfers.  Target details now only shows container modules. No more transfer to an experiment module.
		- Fixed:  When  near debris, SM window sometimes fails to display when icon is clicked from either toolbar.
		- Fixed:  With CLS enabled, selected target part text displayed in Target Crew Color instead of Target Part color.
		- Fixed:  Opening/closing a hatch from the hatch control tab fails to update the CLS spaces.
		- Fixed:  When transferring science, Realism mode prevents moving science to a container in the same part.
		- Fixed:  Disabling Resources in Settings does not remove Resources from the selection list in the Manifest Window.
		- Fixed:  Portraits not properly updating after a crew move.  Bug introduced in 4.1.3 after revisions to actual crew move timing.
* 2015-0410: 4.1.4.4 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.1.4.4 - Release 10 Apr, 2015 - Bug fixes.
		- Fixed:  Crew transfers fail when Realism Mode is Off.
		- Fixed:  SM windows do not hide when the F2 key is toggled to hide UI.
		- Fixed:  SM window positions are not automatically saved between scenes.
		- Fixed:  Roster windows position incorrectly saving to settings window position.
		- Changed:  Altered Window Reposition behavior to be more intuitive.
			- Was:  Reset window to 0.0 when position exceeds the edge of the screen.
			- Now:  reposition window to edge of screen when position exceeds the edge of screen.
* 2015-0407: 4.1.4.3 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.1.4.3 - Release 06 Apr, 2015 - RT bug, External crew bug and control display fixes.
		- Fixed: When using RemoteTech, not all RemoteTech antennas would display in Control window list.
		- Fixed: Sometimes when displaying part info in Antennas, Solar Panels, hatches and Lights, a null exception would occur and "unknown" would be displayed in part parent info.
		- Fixed: Crew in external seats were not properly handled in SM. Attempts to transfer will generate unhanded errors, and could possibly corrupt the game save, requiring the vessel to be deleted.  Removed Crew members in external seats from xfer list.
* 2015-0329: 4.1.4.2 (PapaJoesSoup) for KSP 0.90.0
	+ Version 4.1.4.2 - Release 29 Mar, 2015 - Control Window Tweaks Edition.
		- New: Added part name to description for Antennas, Solar Panels, and Lights in Control Window.
		- Fixed: If CLS is not installed, or CLS is disabled, Control Button is grayed out and Manifest Window is stuck in one position on screen.
* 2015-0323: 0.90.0_4.1.4.1 (PapaJoesSoup) for KSP 0.90.0
	+ Version 0.90.0_4.1.4.1 - Release 22 Mar, 2015 - RT Antenna Integration Edition.
		- New:  Added Remote Tech (RT) Antenna control support.
		- Fixed:  Undeployable Solar panels incorrectly show up in Solar panel list and generate an unmanaged error when Extended or Retracted.
* 2015-0214: 0.90.0_4.0.2 (PapaJoesSoup) for KSP 0.90.0
	+ Version 0.90.0_4.0.2 - Release 13 Feb, 2015 - Bugs, Mod Refactoring and More Edition.
		- New:  Resource Transfer display and setup system refactored.  Added ability to stop a transfer in progress.
		- New:  Exposed Resource Transfer Flow Rate Slider min and max values. You can now change the min and max flow rate.
		- New:  Added a maximum run time in seconds. SM will use the lesser duration of Xfer amount / flow rate or max time.
		- New:  Added tool tips to  controls in the options section of the Settings Window.
		- Fixed:  When moving or transferring a kerbal, closing the transfer window, Manifest window or closing the manifest window from any toolbar while the action is in progress causes an error.
		- Fixed:  When closing the Transfer Window, internally resetting the selected resource causes an error.
* 2015-0115: 0.90.0_3.3.4 (PapaJoesSoup) for KSP 0.90.0
	+ Version 0.90.0_3.3.4 - 15 Jan, 2015 - Bugs, Mod Tweaks and More Edition.
		- New:  Added a Limited Highlighting switch.  When on, highlights only source and target parts.
			- Highlighting switch must be enabled to use.
		- New:  Added close buttons to upper right of most windows.  Cleaned up App launcher toggle button behavior, and synced with close buttons.
		- New:  Added detection for IVA. Hide Ship Manifest Window when in IVA.
		- New:  CLS highlightng returns.  Previous method replaced with new model. Livable parts only will be highlighted by SM.
			- To view passable parts, select the space from the CLS plugin menu.
		- Fixed:  Due to KSP 0.90.0 changes, when using Roster, changes to Kerbal names causes the role to change (bad).
				- Removed ability to edit name of existing Kerbals.
* 2014-1029: 0.25.0_3.3.2b (PapaJoesSoup) for KSP 0.24.0.
	+ Fix for disappearing Stock Toolbar.
* 2014-0928: 0.24.2_3.3.2 (PapaJoesSoup) for KSP 0.24.0.
	+ Version 0.24.2_3.3.2 - 28 Sep, 2014 - 0.24.2 and bug fixes edition
		- New:  Blizzy Toolbar is now optional.  If you install it, you can enable it.  Off by default.
		- New:  Removed auto enable of CLS.  CLS is now Off by default.  If CLS is installed, can be turned on in Settings.
		- New:  Bug fixes to correct crashing and errors on startup.
		- New:  Added Close button to Debug window.
		- New:  Revised Science transfer code to ensure compatibility with DMagic Parts (i hope).
		- Other Undocumented changes.  I was in the middle of other updates (bug fixes) when 0.24.2 hit.
* 2014-0718: 0.24.0.3.3.1 (PapaJoesSoup) for KSP 0.24.0.
	+ Version 0.24.0.3.3.1a - 28 Aug, 2014
		- Removed Toolbar from Distribution. No code changes.
	+ Version 0.24.0.3.3.1 - 17 Jul, 2014 - 0.24.0 Compatibility Edition.
		- New:  Now compatible with KSP 0.24.0. Squad reworked crew objects and namespace.
		- New:  Roster Window now shows vessel to which a kerbal is assigned.
		- New:  Add support for DMagic Science parts (IDataScienceContainer)
		- Bug:  SM Still doubling LS resource amounts.
			- http://forum.kerbalspaceprogram.com/threads/62270-0-23-5-Ship-Manifest-%28Crew-Science-Resources%29-v0-23-5-3-2-2-2-May-14?p=1136419&viewfull=1#post1136419
		- Known Issue:  SM & CLS Highlighting still problematic.
* 2014-0530: 0.23.5.3.3 (PapaJoesSoup) for KSP 0.23
	+ Version 0.23.5.3.3 - 29 May, 2014 - CLS is Optonal Edition.
		- New:  CLS is now a soft dependency.  if you install it, SM will configure for it's use.  If you do not install it, SM will automatically detect that and set Enable CLS Off.
* 2014-0227: 0.23.3.1.5 (PapaJoesSoup) for KSP 0.23
	+ Real time Crew transfers with sound.
	+ Resource transfer amount entry field.
	+ sounds and configs.
* 2014-0128: 0.23.3.0 (PapaJoesSoup) for KSP 0.23
	+ Add crew transfers.  Bug fixes and enhancements.
* 2014-0109: 0.23.2.0 (PapaJoesSoup) for KSP 0.23
	+ Ship Manifest takes Crew manifest's view of Crew and applies it to manage your ship's resources.
	+ Features:
		- Manifest Window. Select resource you want to manage
		- Setting Window. Configure Ship Manager. Changes sounds, realism mode, show/hide debugger
		- Transfer Window. Move resources between parts. In realism mode, initiates xfer pump, moves resource in real time, base on a configurable flow rate.
		- Debugger window. Troubleshoot issues with Ship Manifest.
