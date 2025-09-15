git clone https://github.com/MonoGame/MonoGame MonoGame-v3.8.5-develop.11
cd MonoGame-v3.8.5-develop.11
git checkout v3.8.5-develop.11
(Get-Content ".gitmodules") -replace 'LunarG', 'GPUOpen-LibrariesAndSDKs' | Set-Content ".gitmodules"
git submodule update --init --recursive
dotnet run --project build/Build.csproj