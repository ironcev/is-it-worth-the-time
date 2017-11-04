del aa-t.ps1
rd /s /q Files

copy /y "..\..\src\Common.ps1" .\Common.ps1
copy /y "..\..\src\aa.ps1" .\aa-t.ps1
copy /y "..\..\src\_open-editor.bat" .\_open-editor.bat
copy /y "..\..\src\npp.bat" .\npp-t.bat
copy /y "..\..\src\npp-var.bat" .\npp-var.bat

md "Files\Articles"
type NUL > Files\Articles.txt

"..\..\tools\fart.exe" aa-t.ps1 "c:\Users\Igor\Dropbox\stuffly" "%~dp0%Files"
"..\..\tools\fart.exe" aa-t.ps1 "npp.bat" ".\npp-t.bat"