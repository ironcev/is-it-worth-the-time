@echo off

call pk-var.bat

if [%1]==[] goto:eof

if not [%2]==[] (
    set password=-p"%2" -mem=AES256
) else (
    set password=
)    

setlocal enabledelayedexpansion
for %%i in (%1) do (
    set fileName=%%i
    start "Zip" /i /b /w "%zip%" a "!fileName!.zip" "!fileName!" -tzip %password%
    echo.
    
    if "%deleteOriginalFiles%"=="yes" del "!fileName!"
)
endlocal