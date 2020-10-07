using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace WebView {
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate {
		// class-level declarations
		UIWindow window;
		UINavigationController navigationController;
		UIViewController viewController;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			viewController = new WebViewController();
			
			navigationController = new KeyNavigationController();
			navigationController.PushViewController (viewController, false);

			// If you have defined a view, add it here:
			window.AddSubview (navigationController.View);
			window.RootViewController = navigationController;
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}

	public interface  KeyCommands
	{
	void PerformCommand (Commands command);
	}

	public enum Commands {
		CommandOne = 1,
		CommandTwo = 2,
		CommandThree = 3,
		CommandFour = 4,
        CommandFive = 5
    };

	class KeyNavigationController : UINavigationController, KeyCommands
	{
        public override UIKeyCommand[] KeyCommands
        {
            get
            {
                return new[]{
                    UIKeyCommand.Create((NSString)" ", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandOne")),
                    UIKeyCommand.Create((NSString)"1", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandOne")),
                    UIKeyCommand.Create((NSString)"~1", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandOne")),
                    UIKeyCommand.Create((NSString)"2", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandTwo")),
                    UIKeyCommand.Create((NSString)"~2", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandTwo")),
                    UIKeyCommand.Create((NSString)"3", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandThree")),
                    UIKeyCommand.Create((NSString)"\r", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandThree")),
                    UIKeyCommand.Create((NSString)"~3", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandThree")),
                    UIKeyCommand.Create((NSString)"4", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandFour")),
                    UIKeyCommand.Create((NSString)"~4", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandFour")),
                    UIKeyCommand.Create((NSString)"5", (UIKeyModifierFlags)0, new ObjCRuntime.Selector("commandFive"))

                };
            }
        }

        public override bool CanBecomeFirstResponder
        {
            get { return true; }
        }

        public void PerformCommand(Commands command)
        {
            if (this.TopViewController.IsMemberOfClass(new ObjCRuntime.Class("WebView_WebViewController")))
            {
                WebViewController homeScreen = (WebViewController)TopViewController;
                homeScreen.PerformCommand(command);
            }
        }

        [Export("commandOne")]
        private void OnComandOne()
        {
            this.PerformCommand(Commands.CommandOne);
        }

        [Export("commandTwo")]
        private void OnComandTwo()
        {
            this.PerformCommand(Commands.CommandTwo);
        }

        [Export("commandThree")]
        private void OnComandThree()
        {
            this.PerformCommand(Commands.CommandThree);
        }

        [Export("commandFour")]
        private void OnComandFour()
        {
            this.PerformCommand(Commands.CommandFour);
        }

        [Export("commandFive")]
        private void OnComandFive()
        {
            this.PerformCommand(Commands.CommandFive);
        }
    }
}
