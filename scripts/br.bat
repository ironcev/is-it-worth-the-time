@echo off
call br-var.bat
set fileName=%1
start "Brackets" /i /b "%bracketsExe%" %fileName%