copy /y "..\..\scripts\_open-editor.bat" .\_open-editor-t.bat
copy /y "..\..\scripts\npp.bat" .\npp-t.bat
copy /y "..\..\scripts\npp-var.bat" .\npp-var-t.bat

"..\..\tools\fart.exe" npp-t.bat _open-editor.bat _open-editor-t.bat
"..\..\tools\fart.exe" npp-t.bat npp-var.bat npp-var-t.bat