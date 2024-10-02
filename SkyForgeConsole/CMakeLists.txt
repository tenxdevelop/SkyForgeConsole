# Setup project.
project(SkyForgeConsole VERSION 0.0.1 LANGUAGES CSharp)

add_library(${PROJECT_NAME} SHARED
            Source/Core/EntryPoint.cs 
			Source/Core/IEntryPoint.cs 
			Source/Core/IApplication.cs
			Source/Core/Application.cs)
			
set_target_properties(${PROJECT_NAME} PROPERTIES
                      DOTNET_SDK ${CMAKE_DOTNET_SDK}
                      DOTNET_TARGET_FRAMEWORK ${CMAKE_DOTNET_CORE_VERION}
					  VS_DOTNET_REFERENCES "System;System.Core"
					  VS_GLOBAL_ROOTNAMESPACE ${PROJECT_NAME}
					  RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_OUTPUT_DIRECTORY}
					  ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_OBJECT_OUTPUT_DIRECTORY}
					  LIBRARY_OUTPUT_DIRECTORY ${CMAKE_OBJECT_OUTPUT_DIRECTORY})

target_compile_definitions(${PROJECT_NAME} PUBLIC SKY_FORGE_ENGINE)

if (${CMAKE_SYSTEM} MATCHES "Linux")
	target_compile_definitions(${PROJECT_NAME} PUBLIC SKY_FORGE_LINUX)
elseif(${CMAKE_SYSTEM} MATCHES "Windows")
	target_compile_definitions(${PROJECT_NAME} PUBLIC SKY_FORGE_WINDOWS)
endif()

target_compile_definitions(${PROJECT_NAME} PRIVATE $<$<CONFIG:DEBUG>:SKY_FORGE_DEBUG>)
target_compile_definitions(${PROJECT_NAME} PRIVATE $<$<CONFIG:RELEASE>:SKY_FORGE_RELEASE>)
target_compile_definitions(${PROJECT_NAME} PRIVATE $<$<CONFIG:TEST>:SKY_FORGE_TEST>)

