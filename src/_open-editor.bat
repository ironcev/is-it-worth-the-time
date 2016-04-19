@echo off

if [%1]==[] (
    start "Editor" /i /b "%exe%"
)

SETLOCAL ENABLEDELAYEDEXPANSION
for %%f in (%1) do (
    set fileName=%%f
    start "Editor" /i /b "%exe%" !fileName!
)
ENDLOCAL