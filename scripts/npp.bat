@echo off
call npp-var.bat

if [%1]==[] (
    start "Notepad++" /i /b "%notepadExe%"
)

SETLOCAL ENABLEDELAYEDEXPANSION
for %%f in (%1) do (
    set fileName=%%f
    start "Notepad++" /i /b "%notepadExe%" !fileName!
)
ENDLOCAL