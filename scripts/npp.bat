@echo off
call npp-var.bat
set fileName=%1
start "Notepad++" /i /b "%notepadExe%" %fileName%