@echo off

if [%1]==[] goto:eof

set deleteOriginalFiles=yes

call pk.bat %1 %2

set deleteOriginalFiles=