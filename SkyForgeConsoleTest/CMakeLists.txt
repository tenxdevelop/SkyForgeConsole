#Setup project
project(SkyForgeConsole VERSION 0.0.1 LANGUAGES CSharp)

set(TARGET_NAME "SkyForgeConsoleTest")

set(NUGET_LIBRARY "Microsoft.NET.Test.Sdk_17.6.0;NUnit_3.13.3;NUnit3TestAdapter_4.2.1;NUnit.Analyzers_3.6.1;coverlet.collector_6.0.0")

add_executable(${TARGET_NAME}
               Source/Core/EntryPointTest.cs)


set_target_properties(${TARGET_NAME} PROPERTIES
                      DOTNET_SDK ${CMAKE_DOTNET_SDK}
                      DOTNET_TARGET_FRAMEWORK ${CMAKE_DOTNET_CORE_VERION}
					  VS_DOTNET_REFERENCES "System;System.Core"
					  VS_GLOBAL_ROOTNAMESPACE ${TARGET_NAME}
					  RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_OUTPUT_DIRECTORY}
					  ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_OBJECT_OUTPUT_DIRECTORY}
					  LIBRARY_OUTPUT_DIRECTORY ${CMAKE_OBJECT_OUTPUT_DIRECTORY})

set_property(TARGET ${TARGET_NAME} PROPERTY VS_PACKAGE_REFERENCES ${NUGET_LIBRARY})

target_compile_definitions(${TARGET_NAME} PUBLIC SKY_FORGE_ENGINE)

if (${CMAKE_SYSTEM} MATCHES "Linux")
	target_compile_definitions(${TARGET_NAME} PUBLIC SKY_FORGE_LINUX)
elseif(${CMAKE_SYSTEM} MATCHES "Windows")
	target_compile_definitions(${TARGET_NAME} PUBLIC SKY_FORGE_WINDOWS)
endif()

target_compile_definitions(${TARGET_NAME} PRIVATE $<$<CONFIG:DEBUG>:SKY_FORGE_DEBUG>)
target_compile_definitions(${TARGET_NAME} PRIVATE $<$<CONFIG:RELEASE>:SKY_FORGE_RELEASE>)
target_compile_definitions(${TARGET_NAME} PRIVATE $<$<CONFIG:TEST>:SKY_FORGE_TEST>)

target_link_libraries(${TARGET_NAME} SkyForgeConsole)