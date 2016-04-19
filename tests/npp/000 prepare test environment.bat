copy /y "..\..\src\_open-editor.bat" .\_open-editor-t.bat
copy /y "..\..\src\npp.bat" .\npp-t.bat
copy /y "..\..\src\npp-var.bat" .\npp-var-t.bat

"..\..\tools\fart.exe" npp-t.bat _open-editor.bat _open-editor-t.bat
"..\..\tools\fart.exe" npp-t.bat npp-var.bat npp-var-t.bat