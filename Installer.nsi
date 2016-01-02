Name "FreeSOLauncherZ"

Outfile "FreeSOLauncherZInst.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$PROFILE\FreeSO"

Section "Main"

	SetOutPath '$INSTDIR'

	File "FreeSOLauncherZ\bin\Release\FreeSOLauncherZ.exe"
	File "FreeSOLauncherZ\bin\Release\FreeSOLauncherZ.exe.config"
	File "FreeSOLauncherZ\bin\Release\FreeSOLauncherZ.pdb"
	
	 # create the uninstaller
    WriteUninstaller "$INSTDIR\Uninstall FreeSOLauncherZ.exe"
	
	# create start menu shortcut
	CreateDirectory "$SMPROGRAMS\FreeSO\"
    CreateShortCut "$SMPROGRAMS\FreeSO\FreeSO.lnk" "$INSTDIR\FreeSOLauncherZ.exe"
	CreateShortCut "$SMPROGRAMS\FreeSO\Uninstall FreeSOLauncherZ.lnk" "$INSTDIR\Uninstall FreeSOLauncherZ.exe"

	# create desktop shortcut
  	CreateShortCut "$DESKTOP\FreeSO.lnk" "$INSTDIR\FreeSOLauncherZ.exe"
	
SectionEnd


Section "Uninstall"
 
    # first, delete the uninstaller
    Delete "$INSTDIR\Uninstall FreeSOLauncherZ.exe"
	Delete "$INSTDIR\FreeSOLauncherZ.exe"
	Delete "$INSTDIR\FreeSOLauncherZ.exe.config"
	Delete "$INSTDIR\FreeSOLauncherZ.pdb"
 
    # second, remove the link from the start menu
    Delete "$DESKTOP\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\FreeSO.lnk" 
 
SectionEnd