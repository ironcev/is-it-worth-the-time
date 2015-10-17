copy /y "..\..\scripts\npp.bat" .\npp-t.bat
copy /y "..\..\scripts\npp-var.bat" .\npp-var-t.bat

"..\..\tools\fart.exe" npp-t.bat npp-var.bat npp-var-t.bat