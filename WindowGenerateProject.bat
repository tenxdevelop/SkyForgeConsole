color 0b

mkdir build

cd build

call ..\SkyForgeConsole\Vendor\CMake\bin\cmake.exe -G "Visual Studio 17 2022" ..

call python ..\SkyForgeConsole\Vendor\CMake\extentions\extentionCmake.py SkyForgeConsole\SkyForgeConsole.csproj CMakeCache.txt

call python ..\SkyForgeConsole\Vendor\CMake\extentions\extentionCmake.py SkyForgeConsoleTest\SkyForgeConsoleTest.csproj CMakeCache.txt

pause