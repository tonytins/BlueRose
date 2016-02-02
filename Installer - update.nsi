Name "Blue Rose 2.0 Updater"

Outfile "BlueRoseUpdate.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$EXEDIR\"

Section "Main"

	SetOutPath '$INSTDIR'

	File "BlueRose\bin\Release\BlueRoseLauncher.exe"
	File "BlueRose\bin\Release\BlueRoseLauncher.exe.config"
	File "BlueRose\bin\Release\BlueRoseLauncher.pdb"
	File "BlueRose\bin\Release\BlueRose.Distro.dll"
	File "BlueRose\bin\Release\BlueRose.Distro.pdb"
	File "BlueRose\bin\Release\Ionic.Zip.dll"
	File "BlueRose\bin\Release\Ionic.Zip.xml"
	
SectionEnd