REM @echo off

call pk-var.bat

if [%1]==[] goto:eof

setlocal enabledelayedexpansion
for %%i in (%1) do (
    set fileName=%%i
    if not [%2]==[] (
        set password=-p%2
    ) else (
        set password=
    )    
    start "Zip" /i /b /w "%zip%" a !fileName!.zip !fileName! !password! -mem=AES256
    echo.
    
    if "%deleteOriginalFiles%"=="yes" del !fileName!
)
endlocal