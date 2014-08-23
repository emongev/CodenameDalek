using System;
using System.Collections;
using UnityEngine;
using InControl;


public class SimpleKeyboardProfile : UnityInputDeviceProfile
{
	public SimpleKeyboardProfile()
	{
		Name = "Keyboard";
		Meta = "A keyboard profile for platformers";

		// This profile only works on desktops.
		SupportedPlatforms = new[]
		{
			"Windows",
			"Mac",
			"Linux"
		};

		Sensitivity = 1.0f;
		LowerDeadZone = 0.0f;
		UpperDeadZone = 1.0f;

		ButtonMappings = new[]
		{
			new InputControlMapping
			{
				Handle = "Action",
				Target = InputControlType.Action3,
				Source = KeyCodeButton( KeyCode.LeftControl )
			},
			new InputControlMapping
			{
				Handle = "Jump",
				Target = InputControlType.Action1,
				Source = KeyCodeButton( KeyCode.Space )
			},
			new InputControlMapping
			{
				Handle = "Action Alternate 1",
				Target = InputControlType.Action3,
				Source = KeyCodeButton( KeyCode.X )
			},
			new InputControlMapping
			{
				Handle = "Jump Alternate 1",
				Target = InputControlType.Action1,
				Source = KeyCodeButton( KeyCode.Z )
			}
		};

		AnalogMappings = new[]
		{
			new InputControlMapping
			{
				Handle = "Move X",
				Target = InputControlType.LeftStickX,
				// KeyCodeAxis splits the two KeyCodes over an axis. The first is negative, the second positive.
				Source = KeyCodeAxis( KeyCode.A, KeyCode.D )
			},
			new InputControlMapping
			{
				Handle = "Move Y",
				Target = InputControlType.LeftStickY,
				// Notes that up is positive in Unity, therefore the order of KeyCodes is down, up.
				Source = KeyCodeAxis( KeyCode.S, KeyCode.W )
			},
			new InputControlMapping {
				Handle = "Move X Alternate",
				Target = InputControlType.LeftStickX,
				Source = KeyCodeAxis( KeyCode.LeftArrow, KeyCode.RightArrow )
			},
			new InputControlMapping {
				Handle = "Move Y Alternate",
				Target = InputControlType.LeftStickY,
				Source = KeyCodeAxis( KeyCode.DownArrow, KeyCode.UpArrow )
			}
		};
	}
}


