param(
    [string]$Articles=(Read-Host "Articles"),
    [string]$StufflyDirectory="c:\Users\Igor\Dropbox\stuffly\",
    [switch]$CreateStufflyFiles=$false,
    [switch]$DoNotOpenNpp=$false
)

. (Join-Path $PSScriptRoot "Common.ps1")

$currentDirectory = New-Object System.IO.DirectoryInfo $(Get-Location)
$articlesStufflyFile = (Join-Path $StufflyDirectory "Articles.txt")
$articlesBackupFile = (Join-Path $StufflyDirectory "Articles.backup.txt")
$date = [System.DateTime]::Today.ToString("yyyy.MM.dd")

AssertThatFileExists $articlesStufflyFile "Check if the StufflyDirectory is properly set."

# Create backup file.
[System.IO.File]::Copy($articlesStufflyFile, $articlesBackupFile, $true)

$articleFiles = $currentDirectory.GetFiles($Articles)

AssertThat ($articleFiles.Length -gt 0) "There are no articles that satisfy the given filter '$($Articles)'."

# Append articles to the articles stuffly file.
$sb = New-Object System.Text.StringBuilder
foreach ($file in $articleFiles) {
    $fileName = [System.IO.Path]::GetFileNameWithoutExtension($file.Name)
    $sb.AppendLine("$($date) $($fileName)") | Out-Null
}
[System.IO.File]::AppendAllText($articlesStufflyFile, $sb.ToString())
Confirmation "The following articles have been added:"
Confirmation $sb.ToString()

# Create stuffly file for the articles.
if ($CreateStufflyFiles) {
    $initialArticleStufflyFileContent = "$($date) `n$($date) `n$($date) `n$($date) `n$($date) `n$($date) `n"
    foreach ($file in $articleFiles) {
        $stufflyFileName = Join-Path $StufflyDirectory "Articles\$([System.IO.Path]::GetFileNameWithoutExtension($file.Name) + ".txt")"
        [System.IO.File]::AppendAllText($stufflyFileName, $initialArticleStufflyFileContent)
        if (!$DoNotOpenNpp) {
            Invoke-Expression -Command ".\npp.bat ""$($stufflyFileName)"""
        }
    }
    Confirmation "Stuffly files have been created for all the articles."
}