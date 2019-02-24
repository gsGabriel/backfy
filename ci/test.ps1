function dotnet-test {
  Push-Location test
  ForEach ($folder in (Get-ChildItem -Path ".\" -Directory -Recurse -Filter "*.Tests")) {dotnet test $folder.FullName -c Release --no-build }
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