
# Calculate variables
$dir = "$PSScriptRoot/$((Get-Date).ToString('yyyy-MM-dd'))"
$releasesIndexFile = "$dir/releases-index.json"

# Ensure directory exists
New-Item -ItemType Directory -Force -Path $dir > $null

# Download the releases index file
Write-Host 'Downloading Releases Index .json file'
Invoke-WebRequest 'https://dotnetcli.azureedge.net/dotnet/release-metadata/releases-index.json' -OutFile $releasesIndexFile

# Read the json
$json = Get-Content $releasesIndexFile | ConvertFrom-Json

# Process each channel
$json.'releases-index' | ForEach-Object {
  $channel = $_.'channel-version'
  $url = $_.'releases.json'

  # echo "$channel @ $url"

  Write-Host "Downloading Release Metadata .json for channel $channel"
  Invoke-WebRequest $url -OutFile "$dir/channel-$channel.json"
}