using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;

namespace SMELuckyDraw.UC
{
	/// <summary>
	/// NumberGroup.xaml 的交互逻辑
	/// </summary>
	public partial class NumberGroup : UserControl
	{
		private int numberCount = 6;

		/// <summary>
		/// So luong Number
		/// </summary>
		public int NumberCount
		{
			get
			{
				return numberCount;
			}

			set
			{
				this.numberCount = value;
			}
		}

		/// <summary>
		/// 最终数字
		/// </summary>
		public int FinalValue { get; set; }

		private List<NumberPanel> listNumber = new List<NumberPanel>();

		//public NumberGroup()
		public NumberGroup()
		{
			InitializeComponent();
		}

		public void Init()
		{
			double baseSpeed = 8;//基础速度
			double stepSpeed = 0.1;//累加速度
			double randomSpeed = 3;//随机速度范围
			Random random = new Random();

			// other numbers
			for (int i = 1; i <= this.numberCount; i++)
			{
				NumberPanel number = new NumberPanel();
				if (i == 6)
				{
					number.Speed = 9;
				}
				else
				{
					number.Speed = baseSpeed + (stepSpeed * i) + random.NextDouble() * randomSpeed;
				}
				stackPanelMain.Children.Add(number);
				listNumber.Add(number);
			}
		}

		public void TurnStart()
		{
			foreach (var item in listNumber)
			{
				item.TurnStart();
			}
		}

		public void TurnStop(int number)
		{
			for (int i = 0; i < this.numberCount; i++)
			{
				int value = (int)(number / Math.Pow(10, 7 - i));
				var item = listNumber[i];
				item.TurnStopAt(value);
			}
		}

		public void TurnStopAt(int idx, int value)
		{
			listNumber[idx].TurnStopAt(value);
		}

		public void HideNumberAt(int idx, bool bHide)
		{
			listNumber[idx].HideNumber(bHide);
		}

		/// <summary>
		/// 判断停止状态
		/// </summary>
		/// <returns></returns>
		public bool IsStoped()
		{
			foreach (var item in listNumber)
			{
				if (!item.IsStopped())
				{
					return false;
				}
			}
			return true;
		}
	}
}
