del aa*-t.bat
rd /s /q Files

copy /y "..\..\scripts\aa.bat" .\aa-t.bat
copy /y "..\..\scripts\aac.bat" .\aac-t.bat
copy /y "..\..\scripts\aa-var.bat" .\aa-var-t.bat

md "Files\Articles"
type NUL > Files\Articles.txt

"..\..\tools\fart.exe" aa-var-t.bat "e:\db\Dropbox\stuffly" "Files"
"..\..\tools\fart.exe" aa-t.bat aa-var.bat aa-var-t.bat
"..\..\tools\fart.exe" aac-t.bat aa.bat aa-t.bat