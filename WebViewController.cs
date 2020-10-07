using System;
using System.IO;
using System.Collections.Generic;
using CoreGraphics;
using System.Linq;
using Foundation;
using UIKit;
using WebKit;

namespace WebView {

	public class WebViewController : UIViewController {

		WKWebView webView; // **
//		NSTimer timer;

		public override bool PrefersStatusBarHidden ()
		{
			return true;
		}

		public override bool CanBecomeFirstResponder{
			get { return true;}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            NavigationController.NavigationBar.BarTintColor = UIColor.Black;
            NavigationController.SetNavigationBarHidden (true, false);
			View.BackgroundColor = UIColor.Black;
            CGRect v = new CGRect(View.Bounds.X, View.Bounds.GetMinY(), View.Bounds.Width, View.Bounds.Height);
			webView = new WKWebView(v, new WKWebViewConfiguration()); // **	
			View.AddSubview(webView);
			/*
UIView statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            statusBar.BackgroundColor = UIColor.Black;
			*/
            string fileName = "Content/index.html"; // remember case-sensitive
			string localHtmlUrl = Path.Combine (NSBundle.MainBundle.BundlePath, fileName);
			webView.LoadRequest(new NSUrlRequest(new NSUrl(localHtmlUrl, false)));
			//webView.ScalesPageToFit = false;
			webView.SizeToFit();
			// if this is false, page will be 'zoomed in' to normal size
			//webView.ScalesPageToFit = true;
			
//			timer = NSTimer.CreateRepeatingScheduledTimer(TimeSpan.FromMilliseconds(5000), OneSecondTimer);
		}

        public void PerformCommand(Commands command)
        {
            switch (command)
            {
                case Commands.CommandOne:
                    webView.EvaluateJavaScriptAsync("Action(4)");
                    break;
                case Commands.CommandTwo:
					webView.EvaluateJavaScriptAsync("Action(3)");
					break;
                case Commands.CommandThree:
					webView.EvaluateJavaScriptAsync("Action(1)");
					break;
                case Commands.CommandFour:
					webView.EvaluateJavaScriptAsync("Action(2)");
					break;
				case Commands.CommandFive:
					webView.EvaluateJavaScriptAsync("toggleButtons(4)");
					break;
			}
        }
    }
}