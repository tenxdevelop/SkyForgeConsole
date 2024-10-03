cmake_minimum_required(VERSION 3.3)


project(SkyForgeConsole VERSION 0.0.1 LANGUAGES CSharp)

if(CMAKE_CONFIGURATION_TYPES)
	set(CMAKE_CONFIGURATION_TYPES "Debug;Release;Test" CACHE STRING "Configurations" FORCE)
	set(CMAKE_EXE_LINKER_FLAGS_TEST "/debug:full /optimize- /warn:3 /errorreport:prompt /define:TEST")
	set(CMAKE_CSharp_FLAGS_TEST "${CMAKE_EXE_LINKER_FLAGS_TEST}")
	set(CMAKE_EXE_LINKER_FLAGS_REP "${CMAKE_EXE_LINKER_FLAGS_TEST}")
	set(CMAKE_SHARED_LINKER_FLAGS_TEST "${CMAKE_EXE_LINKER_FLAGS_TEST}")
endif()

#define version Framework
set(CMAKE_DOTNET_CORE_VERION "net8.0")
set(CMAKE_DOTNET_SDK "Microsoft.NET.Sdk")

# Set the C# language version for all projects.
set(CMAKE_CSharp_FLAGS "/langversion:latest")

# Explicitly set the `PlatformTarget` for C# projects, since AnyCPU can result in 
# System.BadImageFormatException throws, when trying to load C++/CLI assemblies.
if(CMAKE_VS_PLATFORM_NAME STREQUAL "x64")
	set(CMAKE_CSharp_FLAGS "${CMAKE_CSharp_FLAGS} /platform:x64")
elseif(CMAKE_VS_PLATFORM_NAME STREQUAL "ARM64")
	set(CMAKE_CSharp_FLAGS "${CMAKE_CSharp_FLAGS} /platform:x64")
elseif(CMAKE_VS_PLATFORM_NAME STREQUAL "Win32")
	set(CMAKE_CSharp_FLAGS "${CMAKE_CSharp_FLAGS} /platform:x64")
else()
  message(WARNING "Generator platform is set to '${CMAKE_GENERATOR_PLATFORM}', which is not supported by managed projects. Defaulting to 'AnyCPU'...")
  set(CMAKE_CSharp_FLAGS "${CMAKE_CSharp_FLAGS} /platform:AnyCPU")
endif()

#define directory for bin and obj files
set(CMAKE_BINARY_OUTPUT_DIRECTORY "../../bin/")
set(CMAKE_OBJECT_OUTPUT_DIRECTORY "../../bin-int/")

add_subdirectory(ConsoleLog)
add_subdirectory(SkyForgeConsole)
add_subdirectory(SkyForgeConsoleTest)
add_subdirectory(SandBox)