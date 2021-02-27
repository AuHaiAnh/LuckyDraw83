using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using SMELuckyDraw.Logic;
using SMELuckyDraw.Model;
using SMELuckyDraw.Util;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SMELuckyDraw
{
	/// <summary>
	/// WomensDay.xaml 的交互逻辑
	/// </summary>
	public partial class WomensDay : Window
	{
		private DrawLogicWomen _logic = DrawLogicWomen.Instance();
		private DispatcherTimer winnerTimer = new DispatcherTimer();
		private DispatcherTimer stopTimer = new DispatcherTimer();
		private DispatcherTimer autoTimer = new DispatcherTimer();
		private static int delayStopFrom = 0;
		private int stopCounter = delayStopFrom;
		private int autoCounter = 1;
		private int finalValue = 0;
		private string finalValueDesc = "";
		private DrawStatus drawStatus = DrawStatus.STOPPED;
		private bool isAllTurnStopped = false;
		private ImageBrush myBrush = new ImageBrush();

		private bool isBonus = false;

		// animation
		Storyboard story = new Storyboard();
		DoubleAnimation anim1 = new DoubleAnimation();
		DoubleAnimation anim2 = new DoubleAnimation();

		enum DrawStatus
		{
			STOPPED = 0,
			RUNNING,
			STOPPING
		}

		public WomensDay()
		{
			InitializeComponent();
			Init();

			this.Closing += new System.ComponentModel.CancelEventHandler(WomensDay_Closing);
			//this.chkIsAuto.Checked += new RoutedEventHandler(chkIsAuto_Checked);
			//this.chkIsAuto.Unchecked += new RoutedEventHandler(chkIsAuto_Checked);

			//this.chkMute.Checked += new RoutedEventHandler(chkchkMute_Checked);
			//this.chkMute.Unchecked += new RoutedEventHandler(chkchkMute_Checked);

			_logic._mediaApp.MediaEnded += new EventHandler(_mediaApp_MediaEnded);
			_logic._mediaStart.MediaEnded += new EventHandler(_mediaStart_MediaEnded);
			_logic._mediaStop.MediaEnded += new EventHandler(_mediaStop_MediaEnded);

			this.cbBackground.SelectionChanged += new SelectionChangedEventHandler(cbBackground_SelectionChanged);
		}

		#region Event
		#region Delete
		private void cbBackground_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			try
			{
				this.buttonStart.IsEnabled = true;
				this.buttonStop.IsEnabled = false;

				string background = ConfigHelper.Instance().GetAppSettings("Background" + this.cbBackground.SelectedValue.ToString());
				string backgroundColor = ConfigHelper.Instance().GetAppSettings("Background" +
											this.cbBackground.SelectedValue.ToString() + "Color");
				string imagePath = Path.Combine("image/", background);

				this.myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), imagePath));
				this.Background = this.myBrush;

				this.lblSubContent.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
				this.lbWinner.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));
				this.lbMsg.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(backgroundColor));

				if (this.cbBackground.SelectedValue.ToString().Equals("2"))
				{
					this.isBonus = true;
				}
				else
				{
					this.isBonus = false;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		//private void chkIsAuto_Checked(object sender, RoutedEventArgs e)
		//{
		//    try
		//    {
		//        if (this.chkIsAuto.IsChecked.Value)
		//        {
		//            this.buttonStop.Visibility = System.Windows.Visibility.Collapsed;
		//        }
		//        else
		//        {
		//            this.buttonStop.Visibility = System.Windows.Visibility.Visible;
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        throw;
		//    }
		//}

		//private void chkchkMute_Checked(object sender, RoutedEventArgs e)
		//{
		//    try
		//    {
		//        if (this.chkMute.IsChecked.Value)
		//        {
		//            _logic._mediaApp.IsMuted = true;
		//            _logic._mediaStart.IsMuted = true;
		//            _logic._mediaStop.IsMuted = true;
		//        }
		//        else
		//        {
		//            _logic._mediaApp.IsMuted = false;
		//            _logic._mediaStart.IsMuted = false;
		//            _logic._mediaStop.IsMuted = false;
		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        throw;
		//    }
		//} 
		#endregion

		private void _mediaStart_MediaEnded(object sender, EventArgs e)
		{
			try
			{
				_logic._mediaStart.Stop();
				_logic._mediaStart.Play();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void _mediaApp_MediaEnded(object sender, EventArgs e)
		{
			try
			{
				_logic._mediaApp.Stop();
				_logic._mediaApp.Play();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void _mediaStop_MediaEnded(object sender, EventArgs e)
		{
			try
			{
				_logic._mediaStop.Stop();

				// Khi Quay Duoc Bonus thi Auto chuyen sang Mode Bonus
				if (this.lbWinner.Content.Equals("☆Bonus☆"))
				{
					// Bonus mode
					this.cbBackground.SelectedIndex = 1;
				}
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void WomensDay_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				_logic.Close();
				_logic._mediaApp.Stop();

				this.Closing -= new System.ComponentModel.CancelEventHandler(WomensDay_Closing);
				//this.chkIsAuto.Checked -= new RoutedEventHandler(chkIsAuto_Checked);
				//this.chkIsAuto.Unchecked -= new RoutedEventHandler(chkIsAuto_Checked);

				//this.chkMute.Checked -= new RoutedEventHandler(chkchkMute_Checked);
				//this.chkMute.Unchecked -= new RoutedEventHandler(chkchkMute_Checked);

				_logic._mediaApp.MediaEnded -= new EventHandler(_mediaApp_MediaEnded);
				_logic._mediaStart.MediaEnded -= new EventHandler(_mediaStart_MediaEnded);
				_logic._mediaStop.MediaEnded -= new EventHandler(_mediaStop_MediaEnded);

				this.cbBackground.SelectionChanged -= new SelectionChangedEventHandler(cbBackground_SelectionChanged);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		//stop timer tick, delay the stop
		private void stopTimer_Tick(object sender, EventArgs e)
		{
			stopCounter++;

			//get the number
			int idx = stopCounter % 3;

			// Delay lai 1s
			if (stopCounter <= 2)
			{
				TurnStopAt(idx - 1);
			}
			Console.WriteLine("stopCounter:" + stopCounter);
			if (stopCounter >= 2) // take care of this number!!!
			{
				_logic._mediaStart.Stop();
				_logic._mediaStop.Play();

				stopTimer.Stop();
				isAllTurnStopped = true;
			}
		}

		//timer tick
		private void timer_Tick(object sender, EventArgs e)
		{
			if (isAllTurnStopped && numberGroupMain.IsStoped())
			{
				stopTimer.Stop();
				lbWinner.Content = finalValueDesc;
				winnerTimer.Stop();

				// Khi ket thuc quay tai Bonus mode: nut Start khong cho nhan nua (khong cho nhan lien tuc 2 lan de tranh nhan nham nut)
				if (this.cbBackground.SelectedValue.ToString().Equals("2"))
				{
					this.buttonStart.IsEnabled = false;
				}
				else
				{
					this.buttonStart.IsEnabled = true;
				}

				ShowAnimation();

				drawStatus = DrawStatus.STOPPED;
				isAllTurnStopped = false;
			}
		}

		private void autoTimer_Tick(object sender, EventArgs e)
		{
			autoCounter++;

			//Het 4s se Start
			if (autoCounter >= 4)
			{
				autoTimer.Stop();
				SelectWinner();
			}
		}

		//start button handler
		private void buttonStart_Click(object sender, RoutedEventArgs e)
		{
			DoDraw();
		}

		//stop button handler
		private void buttonStop_Click(object sender, RoutedEventArgs e)
		{
			SelectWinner();
		}

		private void Window_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter ||
				e.Key == Key.PageDown)
			{
				DoDraw();
			}
			else if (e.Key == Key.PageUp)
			{
				if (this.cbBackground.SelectedIndex != 0 &&
					drawStatus == DrawStatus.STOPPED)
				{
					// Main Mode
					this.cbBackground.SelectedIndex = 0;
				}
			}
			else
			{ 
				// Nothing
			}
		}

		private void btnSunny_Click(object sender, RoutedEventArgs e)
		{
			//DanhSach sw = new DanhSach(_logic);TODO
			//sw.ShowDialog();
		}

		private void btnRest_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Are you sure to reset?", "SYSTEM MESSAGE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				_logic.ResetApp();
				lbMsg.Content = "Please press ENTER to start!";
				this.lbWinner.Content = "";
			}
		}

		private void btnSunny_GotFocus(object sender, RoutedEventArgs e)
		{
			btnBlank.Focus();
		}

		private void btnRest_GotFocus(object sender, RoutedEventArgs e)
		{
			btnBlank.Focus();
		}

		private void Button_GotFocus(object sender, RoutedEventArgs e)
		{
			btnBlank.Focus();
		}
		#endregion

		private void Init()
		{
			numberGroupMain.NumberCount = 2;
			numberGroupMain.Init();

			winnerTimer.Interval = TimeSpan.FromSeconds(1);
			winnerTimer.Tick += new EventHandler(timer_Tick);

			stopTimer.Interval = TimeSpan.FromMilliseconds(1000);
			stopTimer.Tick += new EventHandler(stopTimer_Tick);

			autoTimer.Interval = TimeSpan.FromMilliseconds(1000);
			autoTimer.Tick += new EventHandler(autoTimer_Tick);

			_logic.Init();

			this.lblSubContent.Content = ConfigHelper.Instance().GetAppSettings("SubContent");

			this.cbBackground.Items.Add("1");
			this.cbBackground.Items.Add("2");

			this.cbBackground.SelectedIndex = 0;
			this.isBonus = false;

			string background = ConfigHelper.Instance().GetAppSettings("Background1");
			string imagePath = Path.Combine("image/", background);

			this.myBrush.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), imagePath));
			this.Background = this.myBrush;

			_logic._mediaApp.Play();
		}

		private void ShowAnimation()
		{
			anim1.From = 1;
			anim1.To = 80;
			anim1.Duration = new Duration(TimeSpan.FromMilliseconds(300));
			Storyboard.SetTargetName(anim1, lbWinner.Name);
			Storyboard.SetTargetProperty(anim1, new PropertyPath(Label.FontSizeProperty));

			story.Children.Add(anim1);

			anim2.From = 80;
			anim2.To = 48;
			anim2.Duration = new Duration(TimeSpan.FromMilliseconds(200));
			anim2.BeginTime = TimeSpan.FromMilliseconds(300);
			Storyboard.SetTargetName(anim2, lbWinner.Name);
			Storyboard.SetTargetProperty(anim2, new PropertyPath(Label.FontSizeProperty));

			story.Children.Add(anim2);

			story.Begin(this, true);
		}

		private void DoDraw()
		{
			if (drawStatus == DrawStatus.STOPPING)
			//(drawStatus == DrawStatus.RUNNING 
			//this.chkIsAuto.IsChecked.Value))
			{
				return;
			}
			else if (drawStatus == DrawStatus.STOPPED) // start
			{
				// Neu nut Start Enable thi moi cho Start
				if (this.buttonStart.IsEnabled)
				{
					StartDraw();
				}
			}
			else // stop
			{
				// Khong cho nhan nut Stop nua nen khong dung chuc nang nay tam xoa
				//// Neu nut Stop Enable thi moi cho Stop
				//if (this.buttonStart.IsEnabled)
				//{
				//	SelectWinner();

				//	// Truong Hop Bonus mode: chi cho quay 1 lan, khong the quay 2 lan lien tuc (lo nhan nham nut)
				//	if (this.cbBackground.SelectedValue.ToString().Equals("2"))
				//	{
				//		this.buttonStart.IsEnabled = false;
				//	}
				//}
			}
		}

		private void StartDraw()
		{
			if (!_logic.IsAbleToDraw(this.isBonus))
			{
				showCannotDrawMsg();
				return;
			}

			buttonStart.IsEnabled = false;
			buttonStop.IsEnabled = false; // Khi dang quay khong cho user nhan nut Stop ma de Stop tu dong
			numberGroupMain.TurnStart();
			lbWinner.Content = "";
			winnerTimer.Stop();
			stopCounter = delayStopFrom;
			autoCounter = 1;

			// Tu Dong Dung sau khi quay
			//if (this.chkIsAuto.IsChecked.Value)
			//{
			//    autoTimer.Start();
			//}
			autoTimer.Start();

			_logic._mediaStart.Play();

			drawStatus = DrawStatus.RUNNING;
		}

		private void SelectWinner()
		{
			buttonStop.IsEnabled = false;
			ListGift cdt = _logic.DoDraw(this.isBonus);

			if (cdt != null)
			{
				finalValueDesc = cdt.Name.Trim();
				string winnerId = cdt.STT.Trim();

				finalValue = Convert.ToInt32(winnerId); //remove first char

				stopTimer.Start();
				winnerTimer.Start();

				drawStatus = DrawStatus.STOPPING;
			}
			else
			{
				showCannotDrawMsg();
				numberGroupMain.TurnStop(finalValue);//stop
				winnerTimer.Stop();

				drawStatus = DrawStatus.STOPPED;
			}
		}

		private void TurnStopAt(int idx)
		{
			// lay so tai vi tri number
			int value = (int)(finalValue / Math.Pow(10, this.numberGroupMain.NumberCount - 1 - idx));
			Console.WriteLine("idx: " + idx + "  value: " + value);
			numberGroupMain.TurnStopAt(idx, value);
		}

		private void showCannotDrawMsg()
		{
			lbMsg.Content = "No candidate left! Please reset and try again.";
		}
	}
}
