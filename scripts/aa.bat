@echo off

call aa-var.bat

if [%1]==[] goto:eof

copy "%destinationDirectory%\Articles.txt" "%destinationDirectory%\Articles.backup.txt"

SETLOCAL ENABLEDELAYEDEXPANSION
for %%i in (%1) do (
    set fileName=%%i

    set destinationFile=!fileName!.txt
    set destination="%destinationDirectory%\Articles\!destinationFile!"

    for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
    set "YYYY=!dt:~0,4!" & set "MM=!dt:~4,2!" & set "DD=!dt:~6,2!"

    set "datestamp=!YYYY!.!MM!.!DD!"

    set articleName=!destinationFile:.txt=!

    set article=!datestamp! !articleName!

    @echo !article!>> "%destinationDirectory%\Articles.txt"
    
    if "%createStufflyFile%"=="yes" (
        break>!destination!
    )
)
ENDLOCAL