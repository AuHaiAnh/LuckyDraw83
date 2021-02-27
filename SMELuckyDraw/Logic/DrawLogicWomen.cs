using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using SMELuckyDraw.Model;
using SMELuckyDraw.Util;
using System.Data;
using System.IO;
using System.Windows.Media;

namespace SMELuckyDraw.Logic
{
	public class DrawLogicWomen
	{
		public Dictionary<string, ListGift> _candidateList = new Dictionary<string, ListGift>();
		public Dictionary<string, ListGift> _exceptionList = new Dictionary<string, ListGift>();
		public Dictionary<int, ListGiftRandom> _candidateListRandom = new Dictionary<int, ListGiftRandom>();

		public Dictionary<string, ListGift> _bonusList = new Dictionary<string, ListGift>();
		public Dictionary<string, ListGift> _exceptionBonusList = new Dictionary<string, ListGift>();
		public Dictionary<int, ListGiftRandom> _bonusListRandom = new Dictionary<int, ListGiftRandom>();

		public MediaPlayer _mediaApp = new MediaPlayer();
		public MediaPlayer _mediaStart = new MediaPlayer();
		public MediaPlayer _mediaStop = new MediaPlayer();
		private static DrawLogicWomen _instance = new DrawLogicWomen();
		private bool isInitialized = false;
		private DrawLogicWomen() { }

		public static DrawLogicWomen Instance()
		{
			return _instance;
		}

		public void Init()
		{
			if (isInitialized)
			{
				return;
			}

			try
			{
				prepareCandidateList();
				prepareExceptionList();
				isInitialized = true;

				string currDir = System.AppDomain.CurrentDomain.BaseDirectory;
				string mediaName = ConfigHelper.Instance().GetAppSettings("SoundApp");
				string excelPath = Path.Combine(currDir, "excel");
				excelPath = Path.Combine(excelPath, mediaName);

				_mediaApp.Open(new Uri(excelPath));

				mediaName = ConfigHelper.Instance().GetAppSettings("SoundStart");
				excelPath = Path.Combine(currDir, "excel");
				excelPath = Path.Combine(excelPath, mediaName);

				_mediaStart.Open(new Uri(excelPath));

				mediaName = ConfigHelper.Instance().GetAppSettings("SoundStop");
				excelPath = Path.Combine(currDir, "excel");
				excelPath = Path.Combine(excelPath, mediaName);

				_mediaStop.Open(new Uri(excelPath));
			}
			catch (Exception e)
			{
				throw;
			}
		}

		public void Close()
		{
			ConfigHelper.Instance().CopyAppSettings();
			_mediaStart.Close();
			_mediaStart.Close();
		}

		private void prepareCandidateList()
		{
			//STEP 1, read from excel to DataTable
			string currDir = System.AppDomain.CurrentDomain.BaseDirectory;
			string excelName = ConfigHelper.Instance().GetAppSettings("excelWomen");
			string bonusName = ConfigHelper.Instance().GetAppSettings("excelBonus");
			string excelPath = Path.Combine(currDir, "excel");
			excelPath = Path.Combine(excelPath, excelName);
			DataTable dtCandidates = ExcelHelper.ExcelToDatatable(excelPath, true, false);

			excelPath = Path.Combine(currDir, "excel");
			excelPath = Path.Combine(excelPath, bonusName);
			DataTable dtBonus = ExcelHelper.ExcelToDatatable(excelPath, true, false);

			//STEP2, loop DataTable, put each candidate to list
			if (dtCandidates != null)
			{
				int id = 0;

				foreach (DataRow row in dtCandidates.Rows)
				{
					ListGift cdt = new ListGift();
					cdt.STT = row["STT"].ToString();
					cdt.Name = row["Name"].ToString();
					_candidateList.Add(row["STT"].ToString(), cdt);

					ListGiftRandom candidateRandom = new ListGiftRandom();

					candidateRandom.STT = row["STT"].ToString();
					candidateRandom.Name = row["Name"].ToString();
					candidateRandom.RandomID = 0;
					_candidateListRandom.Add(id++, candidateRandom);
				}
			}

			if (dtBonus != null)
			{
				int id = 0;

				foreach (DataRow row in dtBonus.Rows)
				{
					ListGift cdt = new ListGift();
					cdt.STT = row["STT"].ToString();
					cdt.Name = row["Name"].ToString();
					_bonusList.Add(row["STT"].ToString(), cdt);

					ListGiftRandom candidateRandom = new ListGiftRandom();

					candidateRandom.STT = row["STT"].ToString();
					candidateRandom.Name = row["Name"].ToString();
					candidateRandom.RandomID = 0;
					_bonusListRandom.Add(id++, candidateRandom);
				}
			}
		}

		private void prepareExceptionList()
		{
			string strExcp = ConfigHelper.Instance().GetAppSettings("exceptionList");
			strExcp.TrimEnd();
			strExcp.TrimEnd(',');
			string[] listExcp = strExcp.Split(',');

			foreach (string str in listExcp)
			{
				if (string.IsNullOrWhiteSpace(str))
				{
					continue;
				}

				_exceptionList.Add(str, _candidateList[str]);
			}
		}

		public bool IsAbleToDraw(bool isBonus)
		{
			if (!isBonus)
			{
				return _candidateList.Count > 0 && _candidateList.Count > _exceptionList.Count;
			}

			return _bonusList.Count > 0 && _bonusList.Count > _exceptionBonusList.Count;
		}

		private string getNextNumberFromList(bool isBonus)
		{
			Dictionary<string, ListGift> _tempList = new Dictionary<string, ListGift>();
			Dictionary<string, ListGift> _tempExceptionList = new Dictionary<string, ListGift>();
			Dictionary<int, ListGiftRandom> _tempListRandom = new Dictionary<int, ListGiftRandom>();

			if (isBonus)
			{
				_tempList = this._bonusList;
				_tempExceptionList = this._exceptionBonusList;
				_tempListRandom = this._bonusListRandom;
			}
			else
			{
				_tempList = this._candidateList;
				_tempExceptionList = this._exceptionList;
				_tempListRandom = this._candidateListRandom;
			}

			if (_tempExceptionList.Count >= _tempList.Count)
			{
				return "-1";
			}

			int maxCount = 0;

			Dictionary<int, ListGiftRandom> _candidateListUnlucky = new Dictionary<int, ListGiftRandom>();
			Dictionary<int, ListGiftRandom> _candidateListTemp = new Dictionary<int, ListGiftRandom>();
			int res = 0;
			int id = 0;
			Random random = new Random();

			_candidateListUnlucky =
				_tempListRandom.Where(c => !_tempExceptionList.ContainsKey(c.Value.STT)).ToDictionary(c => c.Key, c => c.Value);

			foreach (ListGiftRandom candidateUnlucky in _candidateListUnlucky.Values)
			{
				ListGiftRandom candidateRandomTemp = new ListGiftRandom();
				double randomID = random.NextDouble();

				candidateRandomTemp.STT = candidateUnlucky.STT;
				candidateRandomTemp.Name = candidateUnlucky.Name;
				candidateRandomTemp.RandomID = randomID;

				_candidateListTemp.Add(id++, candidateRandomTemp);
			}

			id = 0;
			_tempListRandom = _candidateListTemp.OrderBy(c => c.Value.RandomID).ToDictionary(c => id++, c => c.Value);

			maxCount = _tempListRandom.Count;

			Random randomMSNV = new Random();
			res = randomMSNV.Next(0, maxCount);

			return _tempListRandom[res].STT;
		}

		public ListGift DoDraw(bool isBonus)
		{
			string stt = getNextNumberFromList(isBonus);

			//id = -1, no candidate left
			if (stt == "-1")
			{
				return null;
			}

			Dictionary<string, ListGift> _tempList = new Dictionary<string, ListGift>();
			Dictionary<string, ListGift> _tempexceptionList = new Dictionary<string, ListGift>();

			if (isBonus)
			{
				_tempList = this._bonusList;
				_tempexceptionList = this._exceptionBonusList;
			}
			else
			{
				_tempList = this._candidateList;
				_tempexceptionList = this._exceptionList;
				ConfigHelper.Instance().AppendAppSettings("exceptionList", stt + ", ");
			}

			_tempexceptionList.Add(stt, _tempList[stt]);

			return _tempList[stt];
		}

		/// <summary>
		/// Reset app to init state
		/// </summary>
		public void ResetApp()
		{
			_exceptionList.Clear();
			_exceptionBonusList.Clear();
			ConfigHelper.Instance().UpdateAppSettings("exceptionList", "");
		}
	}
}
