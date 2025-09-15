git clone https://github.com/MonoGame/MonoGame MonoGame-develop
cd MonoGame-develop
git submodule update --init --recursive
dotnet run --project build/Build.csproj