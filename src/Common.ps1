function Info($message) {
    Write-Host $message
}

function Warning($message) {
    Write-Host $message -ForegroundColor Yellow
}

function Error($message) {
    Write-Host $message -ForegroundColor Red
}

function Confirmation($message) {
    Write-Host $message -ForegroundColor DarkGreen
}

function AssertThatFileExists($filePath, $helpMessage) {
    if (![System.IO.File]::Exists($filePath)) {
        Error "The file '$($filePath)' does not exist."
        Error $helpMessage
        exit
    }
}

function AssertThat($condition, $helpMessage) {
    if (!$condition) {
        Error $helpMessage
        exit
    }
}