function dotnet-test {
  Push-Location test
  Get-ChildItem -Path ".\" -Directory -Recurse -Filter "*.Tests" | ForEach-Object {
    dotnet test $_ -c Release --no-build
    if ($LastExitCode -ne 0) { Exit $LastExitCode }
  }
  Pop-Location
}

@( "dotnet-test" ) | ForEach-Object {
  echo ""
  echo "***** $_ *****"
  echo ""

  # Invoke function and exit on error
  &$_ 
  if ($LastExitCode -ne 0) { Exit $LastExitCode }
}