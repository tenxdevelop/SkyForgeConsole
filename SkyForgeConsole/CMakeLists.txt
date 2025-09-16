##############################################################
#                                                            #
#                     SKY FORGE CONSOLE                      #
#                                                            #
##############################################################

# Setup project.
project(SkyForgeConsole VERSION 0.0.1 LANGUAGES CSharp)

add_library(${PROJECT_NAME} SHARED
            Source/SkyForgeConsole/Core/EntryPoint.cs 
			Source/SkyForgeConsole/Core/IEntryPoint.cs 
			Source/SkyForgeConsole/Core/IApplication.cs
			Source/SkyForgeConsole/Core/Application.cs
			Source/SkyForgeConsole/Core/Layers/Layer.cs
			Source/SkyForgeConsole/Core/Layers/LayerStack.cs
			Source/SkyForgeConsole/Systems/LogSystem/LogLevel.cs
			Source/SkyForgeConsole/Systems/LogSystem/ILogLevel.cs
			Source/SkyForgeConsole/Systems/LogSystem/ILogger.cs
			Source/SkyForgeConsole/Systems/LogSystem/BaseLogger.cs
			Source/SkyForgeConsole/Systems/LogSystem/ConsoleLogger.cs
			Source/SkyForgeConsole/Systems/LogSystem/FileLogger.cs
			Source/SkyForgeConsole/Systems/LogSystem/ILogSystem.cs
			Source/SkyForgeConsole/Systems/LogSystem/LogSystem.cs
			Source/SkyForgeConsole/Systems/LogSystem/Log.cs
			Source/SkyForgeConsole/Systems/FileSystem/FileSystem.cs
			Source/SkyForgeConsole/Systems/FileSystem/IControllerIO.cs
			Source/SkyForgeConsole/Systems/FileSystem/NetCoreIOController.cs
			Source/SkyForgeConsole/Event/IEvent.cs
			Source/SkyForgeConsole/Event/Event.cs
			Source/SkyForgeConsole/Event/EventCategory.cs
			Source/SkyForgeConsole/Event/EventType.cs
			Source/SkyForgeConsole/Event/KeyboardEvent/KeyEvent.cs
			Source/SkyForgeConsole/Event/KeyboardEvent/KeyPressedEvent.cs
			Source/SkyForgeConsole/Event/KeyboardEvent/KeyReleasedEvent.cs
			Source/SkyForgeConsole/Event/KeyboardEvent/KeyCode.cs
			Source/SkyForgeConsole/Event/KeyboardEvent/KeyCodeExtension.cs
			Source/SkyForgeConsole/Event/KeyboardEvent/IKeyEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/IMouseButtonEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/MouseButtonEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/MouseButtonPressedEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/MouseButtonReleasedEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/IMouseMovedEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/MouseMovedEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/IMouseScrollEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/MouseScrollEvent.cs
			Source/SkyForgeConsole/Event/MouseEvent/MouseButton.cs
			Source/SkyForgeConsole/Systems/InputSystem/IInputSystem.cs
			Source/SkyForgeConsole/Systems/InputSystem/InputSystem.cs
			Source/SkyForgeConsole/Systems/GraphicsSystem/IWindow.cs
			Source/SkyForgeConsole/Systems/GraphicsSystem/IRenderPipeline.cs
			Source/SkyForgeConsole/Systems/GraphicsSystem/Sprite.cs
			Source/SkyForgeConsole/Systems/GraphicsSystem/ConsoleWindow.cs
			Source/SkyForgeConsole/Math/Vector2.cs
			Source/Vendor/Win32/WinAPINative.cs
			Source/Vendor/Win32/WinAPIStruct.cs)
			
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

target_link_libraries(${PROJECT_NAME} ConsoleLog)