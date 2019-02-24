# Version suffix - use preview suffix for CI builds that are not tagged (i.e. unofficial)
$VersionSuffix = ""
if ($env:APPVEYOR -eq "True" -and $env:APPVEYOR_REPO_TAG -eq "false") {
  $VersionSuffix = "preview-" + $env:APPVEYOR_BUILD_NUMBER.PadLeft(4, '0')
}

function dotnet-build {
  Push-Location src/Backfy.Api/
  if ($VersionSuffix.Length -gt 0) {
    dotnet build -c Release --version-suffix $VersionSuffix
  } else {
    dotnet build -c Release
  }
}

@( "dotnet-build" ) | ForEach-Object {
  echo ""
  echo "***** $_ *****"
  echo ""

  # Invoke function and exit on error
  &$_ 
  if ($LastExitCode -ne 0) { Exit $LastExitCode }
}