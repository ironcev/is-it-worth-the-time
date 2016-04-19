del l2m-t.exe
rd /s /q Files

copy /y "..\..\src\l2m\bin\Release\l2m.exe" .\l2m-t.exe

md "Files"

type NUL > Files\Empty.txt

@echo off

(
    echo 2015.01.01
    echo 2015.01.01
    echo 2015.01.01
) >> Files\January2015.txt

(
    echo 2016.01.01 This is a valid entry^|This is a valid translation
    echo 2016.01.01 This is the first invalid entry
    echo 2016.01.01
    echo 2016.01.01 
    echo 2016.01.01Invalid
    echo 2016.01.01 A   B
    echo 2016.01.01 ^|
    echo 2016.01.01 first^|second^|third
    echo 2016.01.01  entry with leading whitespace^|translation
    echo 2016.01.01 entry^| translation
    echo 2016.01.01 This is the last invalid entry
    echo 2016.01.01 This is a valid entry^|This is a valid translation
) >> Files\InvalidEntries.txt

(
    echo 2016.01.09 l'uva^|the grapes
    echo 2016.01.09 il gelato al caffè^|the coffee ice-cream
    echo 2016.01.14 la mucca^|the cow
    echo 2016.01.14 la farfalla^|the butterfly
    echo 2016.01.14 il panino^|the sandwich
    echo 2016.01.14 la caramella^|the candy
    echo 2016.01.15 il topo^|the mouse
    echo 2016.01.15 la scimmia^|the monkey
    echo 2016.01.20 un orso^|a bear
    echo 2016.01.20 il delfino^|the dolphin
    echo 2016.01.20 la formica^|the ant
    echo 2016.01.20 un'ape le api^|a bee; the bees
) >> Files\Italian.txt