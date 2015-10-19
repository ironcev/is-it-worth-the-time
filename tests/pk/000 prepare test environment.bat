del *.txt
del *.zip

copy /y "..\..\scripts\pk.bat" .\pk-t.bat
copy /y "..\..\scripts\pk-var.bat" .\pk-var-t.bat
copy /y "..\..\scripts\pkd.bat" .\pkd-t.bat

"..\..\tools\fart.exe" pk-var-t.bat "..\tools\7za.exe" "..\..\tools\7za.exe"
"..\..\tools\fart.exe" pk-t.bat pk-var.bat pk-var-t.bat
"..\..\tools\fart.exe" pkd-t.bat pk.bat pk-t.bat

type NUL > Test001.txt
type NUL > Test002.txt
type NUL > Test003.txt
