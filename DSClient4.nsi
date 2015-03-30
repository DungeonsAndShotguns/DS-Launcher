; Script created by F1tZy for http://dungeonsandshotguns.org
!define PRODUCT_NAME "DS Minecraft"
;;;;---===Change Me===---;;;;
!define PRODUCT_VERSION "4.1"
!define PRODUCT_PUBLISHER "Dungeons and Shotguns"
!define PRODUCT_WEB_SITE "http://dungeonsandshotguns.org"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\DSMinecraft.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

!include "MUI.nsh"
!define MUI_ABORTWARNING
!define MUI_ICON "DSInstall.ico"
!define MUI_UNICON "DSInstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
;!insertmacro MUI_PAGE_LICENSE "Portals and Undead Horses the stuggle with the currption continues"
; Componet Choice
;!insertmacro MUI_PAGE_COMPONENTS
; Directory page
!insertmacro MUI_PAGE_DIRECTORY
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
;!define MUI_FINISHPAGE_RUN ExecShell "open" "$INSTDIR\DSMinecraft.exe"
!insertmacro MUI_PAGE_FINISH
;!define MUI_PAGE_CUSTOMFUNCTION_LEAVE FinishedInstall
; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES
; Language files
!insertmacro MUI_LANGUAGE "English"

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
;;;;---===Change Me===---;;;;
OutFile "DSClient41.exe"
InstallDir "C:\DS Minecraft"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "Core" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite on
	
  ; Remove All Old Files to prep core
  ;RMDir  /r "$INSTDIR\Data\.minecraft\mods"
  RMDir  /r "$INSTDIR"
  RMDir /r "$SMPROGRAMS\DS Minecraft"
  
  ;Root Files
  SetOutPath "$INSTDIR"
  File /R "FourO\*"
  
  
  CreateDirectory "$SMPROGRAMS\DS Minecraft"
  CreateShortCut "$SMPROGRAMS\DS Minecraft\DS Minecraft.lnk" "$INSTDIR\DSMinecraft.exe"
  CreateShortCut "$SMPROGRAMS\DS Minecraft\CC Emu.lnk" "$INSTDIR\bin\desktop.jar"
  CreateShortCut "$SMPROGRAMS\DS Minecraft\Book Edit.lnk" "$INSTDIR\bin\Revise-StandAlone.jar"
  CreateShortCut "$SMPROGRAMS\DS Minecraft\DS Forums.lnk" "$INSTDIR\Forums.url"
  CreateShortCut "$SMPROGRAMS\DS Minecraft\DS Wiki.lnk" "$INSTDIR\Wiki.url"
  CreateShortCut "$SMPROGRAMS\DS Minecraft\Changelogs.lnk" "$INSTDIR\Changelogs.url"
  CreateShortCut "$DESKTOP\DS Minecraft.lnk" "$INSTDIR\DSMinecraft.exe"
  SetOutPath "$SMPROGRAMS\DS Minecraft"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\AppMainExe.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\AppMainExe.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd

!insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SEC01} "The Core files. You must install these files to play on DS Minecraft."
!insertmacro MUI_FUNCTION_DESCRIPTION_END

Function .onInit
  ;!insertmacro UnselectSection ${SEC02}
  InitPluginsDir
  ;BgImage::SetBg /FILLSCREEN DSLaunch.png
FunctionEnd

;Function .onGUIInit
	;BgImage::SetBg /GRADIENT 0 0x80 0 0x80 0 0
	;!insertmacro GetReturnValue
	# add an image @ (150,0)
	;BgImage::AddImage DSLaunch.png 150 0
	;!insertmacro GetReturnValue
	;BgImage::SetBg /FILLSCREEN DSLaunch.png
    ;BgImage::Redraw
;FunctionEnd

Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) was successfully removed from your computer."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Are you sure you want to completely remove $(^Name) and all of its components?" IDYES +2
  Abort
FunctionEnd

Function FinishedInstall
ExecShell "" "iexplore.exe" "$INSTDIR\a.htm"
FunctionEnd

Section Uninstall
  RMDir  /r "$INSTDIR"
  ;Delete "$INSTDIR\Data\.minecraft\invasion_config.txt"
  ;Delete "$INSTDIR\Data\.minecraft\wirelessRedstone.properties"
  
  RMDir "$SMPROGRAMS\DS Minecraft"
  ;RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd